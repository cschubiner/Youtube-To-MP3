//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using System.IO;

namespace YouTube_Getter
{
    public partial class Form1 : Form
    {
        //internal Form1()
        public Form1()
        {
            InitializeComponent();
        }
        private byte[] downloadedData;
        private Video_Downloader_DLL.VideoDownloader downloadmaker = new Video_Downloader_DLL.VideoDownloader();
      
        private void Button1_Click(object sender, System.EventArgs e)
        {
            string videotitle = "";
            //string thumbnailurl = "";
            string output = "";
            string inputurl = oldTextBox1.Text;
            downloadmaker.GetVideoTitle(inputurl, ref videotitle);
            System.String tempVar = "";
            System.Int32 tempVar2 = 0;
            downloadmaker.MakeDownloadURL(inputurl, ref output, ref tempVar, ref tempVar2);
            //downloadmaker.GetPreviewThumbnail(inputurl, ref thumbnailurl);
            oldOutLink.Text = (videotitle);
            oldLinkText.Text = (output);
            //PicImage.Text = (thumbnailurl);
            MessageBox.Show("To Download " + videotitle + Environment.NewLine + "Please click Download now, When finished Downloading select Save To File");
        }
        private void downloadData(string url)
        {
            oldprogressBar1.Value = 0;

            downloadedData = new byte[0];
            try
            {
                //Optional
                this.Text = "Connecting...";
                Application.DoEvents();

                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
                oldprogressBar1.Maximum = dataLength;
                lbProgress.Text = "0/" + dataLength.ToString();

                this.Text = "Downloading...";
                Application.DoEvents();
                
                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        //Finished downloading
                        oldprogressBar1.Value = oldprogressBar1.Maximum;
                        lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        if (oldprogressBar1.Value + bytesRead <= oldprogressBar1.Maximum)
                        {
                            oldprogressBar1.Value += bytesRead;
                            lbProgress.Text = oldprogressBar1.Value.ToString() + "/" + dataLength.ToString();

                            oldprogressBar1.Refresh();
                            Application.DoEvents();
                        }
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                stream.Close();
                memStream.Close();
            }
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                MessageBox.Show("There was an error accessing the URL.");
            }

            oldtxtData.Text = downloadedData.Length.ToString();
           // this.Text = "YT Snatcher";
        }

        private bool CheckURL(string url)
        {
            oldprogressBar1.Value = 0;

            downloadedData = new byte[0];
            try
            {
                //Optional
                this.Text = "Connecting...";
                Application.DoEvents();

                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
                oldprogressBar1.Maximum = dataLength;
                lbProgress.Text = "0/" + dataLength.ToString();

                this.Text = "Downloading...";
                Application.DoEvents();

                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        //Finished downloading
                        oldprogressBar1.Value = oldprogressBar1.Maximum;
                        lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        if (oldprogressBar1.Value + bytesRead <= oldprogressBar1.Maximum)
                        {
                            oldprogressBar1.Value += bytesRead;
                            lbProgress.Text = oldprogressBar1.Value.ToString() + "/" + dataLength.ToString();

                            oldprogressBar1.Refresh();
                            Application.DoEvents();
                        }
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                stream.Close();
                memStream.Close();
                return true;
            }
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                
                MessageBox.Show("There was an error accessing the URL.");
                return false;
            }

            oldtxtData.Text = downloadedData.Length.ToString();
            this.Text = "YT Snatcher";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            downloadData(oldLinkText.Text);

            //Get the last part of the url, ie the file name
            if (downloadedData != null && downloadedData.Length != 0)
            {
                string ytdata = oldOutLink.Text;
                string urlName = oldLinkText.Text;
                if (urlName.EndsWith("/"))
                    urlName = urlName.Substring(0, urlName.Length - 1); //Chop off the last '/'

                urlName = urlName.Substring(urlName.LastIndexOf('/') + 1);

                saveDiag1.FileName = ytdata + ".flv";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (downloadedData != null && downloadedData.Length != 0)
            {
                if (saveDiag1.ShowDialog() == DialogResult.OK)
                {
                    this.Text = "Saving Data...";
                    Application.DoEvents();

                    //Write the bytes to a file
                    FileStream newFile = new FileStream(saveDiag1.FileName, FileMode.Create);
                    newFile.Write(downloadedData, 0, downloadedData.Length);
                    newFile.Close();

                    this.Text = "Download Data";
                    MessageBox.Show("Saved Successfully");
                }
            }
            else
                MessageBox.Show("No File was Downloaded Yet!");
        }

     

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
           
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Copy;
                else

                    e.Effect = DragDropEffects.None;

        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {

            dragdropdownload(e,true);   
        }

        private void dragdropdownload(DragEventArgs e, bool isMp3)
        {
            try
            {
                string videotitle = "";
                //string thumbnailurl = "";
                string output = "";
                string inputurl = e.Data.GetData(DataFormats.Text).ToString();

                downloadmaker.GetVideoTitle(inputurl, ref videotitle);

                System.String tempVar = "";

                if (isMp3)
                label1.Text = "Downloading...";
                else label9.Text = "Downloading...";
                this.Text = label1.Text + " — YouTube to MP3 Converter";
                System.Int32 tempVar2 = 0;
                downloadmaker.MakeDownloadURL(inputurl, ref output, ref tempVar, ref tempVar2);
                //downloadmaker.GetPreviewThumbnail(inputurl, ref thumbnailurl);
                try{
                oldOutLink.Text = videotitle;}catch{}
                oldLinkText.Text = output;
                //PicImage.Text = (thumbnailurl);
                //  MessageBox.Show("To Download " + videotitle + Environment.NewLine + "Please click Download now, When finished Downloading select Save To File");
                if (isMp3)
                {
                    label2.Text = e.Data.GetData(DataFormats.Text).ToString(); //+ "\n\r" + videotitle;
                    if (textBox1artist.Text == "")
                    {
                        textBox1artist.Text = videotitle;
                        try
                        {
                            textBox1artist.Text = textBox1artist.Text.Substring(0, 30);
                        }
                        catch
                        {

                        }
                    }
                    if (textBox1title.Text == "")
                    {
                        textBox1title.Text = videotitle;
                        try
                        {
                            textBox1title.Text = textBox1title.Text.Substring(0, 30);
                        }
                        catch
                        {

                        }
                    }
                }
                //download phase
                downloadData(oldLinkText.Text);


                //Get the last part of the url, ie the file name
                if (downloadedData != null && downloadedData.Length != 0)
                {
                    string ytdata = oldOutLink.Text;
                    string urlName = oldLinkText.Text;
                    if (urlName.EndsWith("/"))
                        urlName = urlName.Substring(0, urlName.Length - 1); //Chop off the last '/'

                    urlName = urlName.Substring(urlName.LastIndexOf('/') + 1);

                    saveDiag1.FileName = ytdata + ".mp4"; //old was .flv
                }

                //save phase
                string temppath;
                if (isMp3)
                 temppath = Path.GetTempFileName();
                else temppath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\"
                    + Path.GetRandomFileName() + ".mp4";

                if (downloadedData != null && downloadedData.Length != 0)
                {

                    //    this.Text = "Saving Data...";
                    Application.DoEvents();

                    //Write the bytes to a file
                    FileStream newFile = new FileStream(temppath, FileMode.Create);
                    newFile.Write(downloadedData, 0, downloadedData.Length);
                    newFile.Close();

                    //  this.Text = "Download Data";
                    //  MessageBox.Show("Saved Successfully");
                    //  label2.Text = temppath; //delete!
                }
                else
                    MessageBox.Show("No File was Downloaded Yet!");
                if (isMp3)
                {
                    //——————————— 
                    string tempfile = Path.GetRandomFileName();
                    //convert phase
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo stratInfo = new System.Diagnostics.ProcessStartInfo();
                    stratInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    //stratInfo.FileName = "cmd.exe";
                    //stratInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";

                    // stratInfo.FileName = @"C:\Users\Clay\Desktop\YouTube to MP3\YOUTUBE GETTER\YouTube Getter\ffmpeg.exe";
                    stratInfo.FileName = "ffmpeg.exe";
                    //  stratInfo.Arguments = "-i "+temppath+" -vn -ar 44100 -ac 2 -ab 192000 -f mp3 "+@"C:\Users\Clay\Desktop\"+videotitle+".mp3";
                    stratInfo.Arguments = "-b 192k -i " + temppath + " " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\"
                    + tempfile + ".mp3";


                    process.StartInfo = stratInfo;
                    process.Start();

                    if (isMp3)
                    label1.Text = "Converting...";
                    else label9.Text = "Converting...";
                    this.Text = label1.Text + " — YouTube to MP3 Converter";

                    while (process.HasExited == false)
                    {
                        if (process.HasExited)
                        {
                    //        System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                    //        System.Diagnostics.ProcessStartInfo stratInfo2 = new System.Diagnostics.ProcessStartInfo();
                    //        stratInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                    //        stratInfo2.FileName = "mp3gain.exe";
                    //        stratInfo2.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\"
                    //+ tempfile + ".mp3";


                    //        process2.StartInfo = stratInfo;
                    //        process2.Start();

                            //tagging
                          
                                    id3v1Tagger.Tagger myTagger = new id3v1Tagger.Tagger(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\"
                                    + tempfile + ".mp3");
                                    myTagger.Artist = textBox1artist.Text;
                                    myTagger.Title = textBox1title.Text;
                                    myTagger.HasTag = true;
                                    myTagger.WriteID3v11();


                                   
                                
                            

                            //  System.Diagnostics.Process.Start(stratInfo2.FileName, stratInfo2.Arguments);
                        }
                    }
                    //System.Diagnostics.Process.Start(stratInfo.FileName, stratInfo.Arguments);
                }
                if (isMp3)
                label1.Text = "Task Complete";
                else label9.Text = "Task Complete";
                this.Text = label1.Text + " — YouTube to MP3 Converter";



            }
            catch (UriFormatException)
            {
                MessageBox.Show("Not a URL");
            }


        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else

                e.Effect = DragDropEffects.None;

       
            
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
                dragdropdownload(e, false);   
        }

     

      
    }
}

        

    
