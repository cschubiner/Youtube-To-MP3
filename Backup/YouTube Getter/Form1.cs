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
            string inputurl = TextBox1.Text;
            downloadmaker.GetVideoTitle(inputurl, ref videotitle);
            System.String tempVar = "";
            System.Int32 tempVar2 = 0;
            downloadmaker.MakeDownloadURL(inputurl, ref output, ref tempVar, ref tempVar2);
            //downloadmaker.GetPreviewThumbnail(inputurl, ref thumbnailurl);
            OutLink.Text = (videotitle);
            LinkText.Text = (output);
            //PicImage.Text = (thumbnailurl);
            MessageBox.Show("To Download " + videotitle + Environment.NewLine + "Please click Download now, When finished Downloading select Save To File");
        }
        private void downloadData(string url)
        {
            progressBar1.Value = 0;

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
                progressBar1.Maximum = dataLength;
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
                        progressBar1.Value = progressBar1.Maximum;
                        lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        if (progressBar1.Value + bytesRead <= progressBar1.Maximum)
                        {
                            progressBar1.Value += bytesRead;
                            lbProgress.Text = progressBar1.Value.ToString() + "/" + dataLength.ToString();

                            progressBar1.Refresh();
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

            txtData.Text = downloadedData.Length.ToString();
            this.Text = "YT Snatcher";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            downloadData(LinkText.Text);

            //Get the last part of the url, ie the file name
            if (downloadedData != null && downloadedData.Length != 0)
            {
                string ytdata = OutLink.Text;
                string urlName = LinkText.Text;
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
    }
}

        

    
