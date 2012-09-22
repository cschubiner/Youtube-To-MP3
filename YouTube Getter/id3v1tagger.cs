/*
 * Created by SharpDevelop.
 * User: Merlin Hunter
 * Date: 31.05.2005
 * Time: 19:33
 * 
 * You may use this code for all purposes,
 * but you use this code at your own risk.
 */

using System;
using System.IO;
using System.Text;

namespace id3v1Tagger
{
	/// <summary>
	/// Description of LTTagger.
	/// </summary>
	public class Tagger
	{
		private string filePath;
		
		/* Used Standard: ID3v1.1
		 * This standard uses one byte of the comment field to insert a title number
		 */
		private byte[] buffer = new byte[128]; //buffer for read an write actions
		private string title = "";		//Byte 4-33
		private string artist = "";		//Byte 34-63
		private string album = "";		//Byte 64-93
		private string year = "";		//Byte 94-97
		private string comment = "";	//Byte 98-125
		//Byte 126 is a Zero Byte Seperator
		private string titleNumber = "";//Byte 127
		private string genre = "255";	//Byte 128
		private bool hasTag = false;
		private bool hadTag = false;
		private string fullFilePath = "";
		
		public Tagger(string filePath)
		{
			this.filePath = filePath;
			
			//if the file doesn't exist, we needn't to work further
			if(!File.Exists(filePath))
				throw new FileNotFoundException("Datei nicht gefunden", filePath);
			IntializeID3v1Variables(this.filePath);
		}
		
		private void IntializeID3v1Variables(string filePath)
		{
			FileInfo myFile = new FileInfo(filePath);
			fullFilePath = myFile.FullName;
			/*
			 * if the file ist smaller than 128 byte, there can't be a ID3v1 tag.
			 * Even a MP3 file with such size isn't possible, but the user should decide
			 * if he want add a ID3v1
			 */
			if(myFile.Length <= 128)
			{
			}
			
			else
			{
				Stream fileStream = myFile.OpenRead();
				fileStream.Seek(-128, SeekOrigin.End);				//speed up to needed position
				for(int i = 0; i < 128; i++)
				{
					buffer[i] = (byte)fileStream.ReadByte();
				}
				fileStream.Close();									//close fileStream
				if(Encoding.Default.GetString(buffer, 0, 3).Equals("TAG"))
				{
					this.hasTag = true;
					this.hadTag = true;
					this.title = Encoding.Default.GetString(buffer, 3, 30);
					this.artist = Encoding.Default.GetString(buffer, 33, 30);
					this.album = Encoding.Default.GetString(buffer, 63, 30);
					this.year = Encoding.Default.GetString(buffer, 93, 4);
					this.comment = Encoding.Default.GetString(buffer, 97, 28);
					if(Convert.ToInt32(buffer[126]) <= 147)
						this.titleNumber = (Convert.ToInt32(buffer[126])).ToString();
					if(Convert.ToInt32(buffer[127]) > 0)
						this.genre = (Convert.ToInt32(buffer[127])).ToString();
				}
			}
		}
		
		#region properties for setting and getting the fields
		public bool HasTag
		{
			get{return this.hasTag;}
			set{this.hasTag = value;}
		}
		
		/// <summary>
		/// sets or reads the title. If there's a size over 30 characters, it throws a FormatException
		/// </summary>
		public string Title
		{
			get{return this.title;}
			set
			{
				if(value.Length > 30)
					throw new FormatException("Der Text ist länger als 30 Zeichen, und könnte deswegen nicht gespeichert werden.");
				this.title = value;
				
				//change the data first to a byte-array, and copy that array in the buffer
				byte[] temp = new byte[30];
				StringToByte(value).CopyTo(temp, 0);
				temp.CopyTo(buffer, 3);
			}
		}
		
		/// <summary>
		/// sets or reads the artist. If there's a size over 30 characters, it throws a FormatException
		/// </summary>
		public string Artist
		{
			get{return this.artist;}
			set
			{
				if(value.Length > 30)
					throw new FormatException("Der Text ist länger als 30 Zeichen, und könnte deswegen nicht gespeichert werden.");
				this.artist = value;
				
				//change the data first to a byte-array, and copy that array in the buffer
				byte[] temp = new byte[30];
				StringToByte(value).CopyTo(temp, 0);
				temp.CopyTo(buffer, 33);
			}
		}
		
		/// <summary>
		/// sets or reads the album. If there's a size over 30 characters, it throws a FormatException
		/// </summary>
		public string Album
		{
			get{return this.album;}
			set
			{
				if(value.Length > 30)
					throw new FormatException("Der Text ist länger als 30 Zeichen, und könnte deswegen nicht gespeichert werden.");
				this.album = value;
				
				//first change the data to a byte-array, and copy that array in the buffer
				byte[] temp = new byte[30];
				StringToByte(value).CopyTo(temp, 0);
				temp.CopyTo(buffer, 63);
			}
		}
		
		/// <summary>
		/// sets or reads the year. If there's a size over 4 characters, it throws a FormatException
		/// </summary>
		public string Year
		{
			get{return this.year;}
			set
			{
				if(value.Length > 4)
					throw new FormatException("Der Text ist länger als 4 Zeichen, und könnte deswegen nicht gespeichert werden.");
				this.year = value;
				
				//change the data first to a byte-array, and copy that array in the buffer
				byte[] temp = new byte[4];
				StringToByte(value).CopyTo(temp, 0);
				temp.CopyTo(buffer, 93);
			}
		}
		
		/// <summary>
		/// sets or reads the comment. If there's a size over 28 characters, it throws a FormatException
		/// </summary>
		public string Comment
		{
			get{return this.comment;}
			set
			{
				if(value.Length > 28)
					throw new FormatException("Der Text ist länger als 28 Zeichen, und könnte deswegen nicht gespeichert werden.");
				this.comment = value;
				
				//change the data first to a byte-array, and copy that array in the buffer
				//Note: normally the comment field has 29 bytes, but the last byte is a
				//zero byte seperator
				byte[] temp = new byte[29];
				StringToByte(value).CopyTo(temp, 0);
				temp.CopyTo(buffer, 97);
			}
		}
		
		/// <summary>
		/// sets or reads the title number. If the value is greater than 255
		/// or smaller than 0 or the value is not a number, it throws a FormatException
		/// </summary>
		public string TitleNumber
		{
			get{return this.titleNumber;}
			set
			{
				if(value.Equals(""))
					value = "0";
				if(Int32.Parse(value) > 255)
					throw new FormatException("Die eingegebene Zahl ist größer als 255, und könnte deswegen nicht korrekt gespeichert werden.");
				if(Int32.Parse(value) < 0)
					throw new FormatException("Die eingegebene Zahl ist kleiner als 0, und könnte deswegen nicht korrekt gespeichert werden");
				this.titleNumber = value;
				//format the data and write it to the buffer
				buffer[126] = Convert.ToByte(value);
			}
		}
		
		/// <summary>
		/// sets or reads the GenreID. If the value is greater than 255
		/// or smaller than 0 or the value is not a number, it throws a FormatException
		/// </summary>
		public string GenreID
		{
			get
			{
				if(hasTag)
					return this.genre;
				else
					return "";
			}
			set
			{
				if(value.Equals(""))
					value = "255";
				if(Int32.Parse(value) > 255)
					throw new FormatException("Die eingegebene Zahl ist größer als 255, und könnte deswegen nicht korrekt gespeichert werden.");
				this.genre = value;
				//format the data and writh it to the buffer
				buffer[127] = Convert.ToByte(value);
			}
		}
		
		/// <summary>
		/// reads the genreID and returns the genre name as string. If theres a ID over 147
		/// it return an empty string
		/// </summary>
		public string GenreName
		{
			get
			{
				if(Int32.Parse(this.genre) < 147)
					return "";
				else
					return GenreDB.GenreList[Int32.Parse(this.genre)];
			}
		}
		#endregion
		public string FullFilePath
		{
			get{return fullFilePath;}
		}
		
		public long FileSize
		{
			get{return (new FileInfo(fullFilePath)).Length;}
		}
		
		private Byte[] StringToByte(string stringToConvert)
		{
			Byte[] message = Encoding.Default.GetBytes(stringToConvert.ToCharArray());
			return message;
		}
		
		
		/// <summary>
		/// This method writes the data. If the file is in use it will throw
		/// an IOException
		/// </summary>
		public void WriteID3v11()
		{
			//first change the data to a byte-array, and copy that array in the buffer
			bool bHandled = false;
			byte[] temp = new byte[3];
			StringToByte("TAG").CopyTo(temp, 0);
			temp.CopyTo(buffer, 0);
			
			FileInfo myFile = new FileInfo(filePath);
			FileStream myStream = myFile.OpenWrite();
			
			//there was a tag, which now will be updated
			if(hadTag & hasTag & !bHandled)
			{
				bHandled = true;
				myStream.Seek(-128, SeekOrigin.End);
				myStream.Write(buffer, 0, 128);
			}
			
			//It didn't exist a tag, now one will be inserted
			if(!hadTag & hasTag & !bHandled)
			{
				bHandled = true;
				hadTag = true;
				myStream.Seek(0, SeekOrigin.End);
				myStream.Write(buffer, 0, 128);
			}
			
			//Nothing will change. No tag existed, no tag will be inserted
			if(!hadTag & !hasTag & !bHandled)
			{
				bHandled = true;
			}
			
			//It existed a tag, which will be deleted
			if(hadTag & !hasTag & !bHandled)
			{
				bHandled = true;
				hadTag = false;
				myStream.SetLength(myStream.Length - 128);
			}
			
			myStream.Close();
		}
	}
	
	/// <summary>
	/// Central genre enumeration. It raises clarity and reduces ram usage
	/// </summary>
	public class GenreDB
	{
		private static string[] genreList = new string[]
		{
			"Blues", "Classic Rock", "Country", "Dance", "Disco", "Funk", "Grunge", "Hip-Hop", "Jazz",
			"Metal", "New Age", "Oldies", "Other Genre", "Pop", "R&B", "Rap", "Reggae", "Rock", "Techno",
			"Industrial", "Alternative", "Ska", "Death Metal", "Pranks", "Soundtrack", "Euro-Techno",
			"Ambient", "Trip-Hop", "Vocal", "Jazz&Funk", "Fusion", "Trance", "Classical", "Instrumental",
			"Acid", "House", "Game", "Sound Clip", "Gospel", "Noise", "Alternativ Rock", "Bass", "Soul",
			"Punk", "Space", "Meditative", "Instrumental Pop", "Instrumental Rock", "Ethnic", "Gothic",
			"Darkwave", "Techno-Industrial", "Electronic", "Pop-Folk", "Eurodance", "Dream", "Southern Rock",
			"Comedy", "Cult", "Gangsta", "Top 40", "Christian Rap", "Pop/Funk", "Jungle", "Native US",
			"Carbaret", "New Wave", "Psychedelic", "Rave", "Showtunes", "Trailer", "Lo-Fi", "Tribal", "Acid Punk",
			"Acid Jazz", "Polka", "Retro", "Musical", "Rock & Roll", "Hard Rock", "Folk",
			/*Winamp Extensions*/
			"Folk-Rock", "National Folk", "Swing", "Fast Fusion", "Bebop", "Latin", "Revival", "Celtic",
			"Bluegrass", "Avantgarde", "Gothic Rock", "Progressive Rock", "Psychadelic Rock", "Symphonic Rock",
			"Slow Rock", "Big Band", "Chorus", "Easy Listening", "Acoustic", "Homour", "Speech", "Chanson",
			"Opera", "Chamber Music", "Sonata", "Symphony", "Booty Bass", "Primus", "Porn Groove",
			"Satire", "Slow Jam", "Club", "Tango", "Samba", "Folklore", "Ballad", "Power Ballad",
			"Rythmic Soul", "Freestyle", "Duet", "Punk Rock", "Drum Solo", "Acapella", "Euor-House",
			"Dance Hall", "Goa", "Drum & Bass", "Club-House", "Hardcore", "Terror", "Indie", "BritPop",
			"Negerpunk", "Polsk Punk", "Beat", "Christian Gangsta", "Heavy Metal", "Black Metal", "Crossover",
			"Contemporary", "Christian Rock", "Merengue", "Salsa", "Trash Metal", "Anime", "JPop", "SynthPop"
		};
		
		//Property to get the whole list
		public static string[] GenreList{get{return genreList;}}
		
		public static string GetGenreID(string genre)
		{
			int genreID = 255;
			for(int i = 0; i < genreList.Length; i++)
			{
				if(genre.ToLower().Equals(genreList[i].ToLower()))
				{
					genreID = i;
					break;
				}
			}
			
			return genreID.ToString();
		}
	}
}
