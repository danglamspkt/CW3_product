using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Cw3_Product.UserControlMenu;
using Cw3_Product.UserControlKeHoach;
using Cw3_Product.Model;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;
using Cw3_Product.UserControlSanXuat;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media;
using System.Data.SqlTypes;
using System.CodeDom;
using QRCoder;
using System.Reflection.Emit;
using System.Windows.Interop;
using QRCoder.Xaml;

namespace Cw3_Product.ViewModel
{
    
    public class TestViewModel : BaseViewModel
    {
        private string _sourceimg;
        public string sourceimg { get => _sourceimg; set { _sourceimg = value; OnPropertyChanged(); } }

        private string _qrtext;
        public string qrtext { get => _qrtext; set { _qrtext = value; OnPropertyChanged(); } }
        int i = 0;
        int j = 0;
        int k = 0;
        public ICommand buttoncommand { get; set; }
        public ICommand loadimgcommand { get; set; }
        public ICommand QRcommand { get; set; }
        string text;
        public TestViewModel()
        {
            i = 0;
            j = 0;
            k = 0;

            buttoncommand = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {

                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                //ofd.FilterIndex = 1;
                //ofd.RestoreDirectory = true;
                //if (ofd.ShowDialog() == ofd.OK)
                //{
                //    text = ofd.FileName;
                //    image.Source = new BitmapImage(new Uri(ofd.FileName));
                //}

                //var imageBuffer = BitmapSourceToByteArray((BitmapSource)image.Source);
                //DataProvider.Ins.DB.NhanSu.First().HinhAnh = imageBuffer;

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                //dlg.ShowDialog();
                dlg.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == true)
                {
                    try
                    {
                        i++;
                        Image image = new Image { Width = 500, Height = 500, Stretch = Stretch.Uniform };

                        FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

                        fs.Close();

                        ImageSourceConverter img = new ImageSourceConverter();
                        image.SetValue(Image.SourceProperty, img.ConvertFromString(dlg.FileName.ToString()));
                        if (i > 1) { p.Children.RemoveAt(i - 1); i -= 1; }
                        p.Children.Add(image);

                        var imageBuffer = BitmapSourceToByteArray((BitmapSource)image.Source);
                        DataProvider.Ins.DB.NhanSu.First().HinhAnh = imageBuffer;
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception) 
                    { 

                    }

                }

            });

            loadimgcommand = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {

                j++;
                Image image = new Image { Width = 500, Height = 500, Stretch = Stretch.Uniform };
                var bitmap = LoadImage(DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == "1701032266").First().HinhAnh);
                image.Source = bitmap;
                if (j > 1) { p.Children.RemoveAt(j - 1); j -= 1; }
                p.Children.Add(image);

            });


            QRcommand = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {

                k++;
                Image image = new Image { Width = 500, Height = 500, Stretch = Stretch.Uniform };
               
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrtext, QRCodeGenerator.ECCLevel.H);
                XamlQRCode qrCode = new XamlQRCode(qrCodeData);
                DrawingImage qrCodeAsXaml = qrCode.GetGraphic(20,"red","white",false);

                image.Source = qrCodeAsXaml;
                if (k > 1) { p.Children.RemoveAt(k); k -= 1; }
                p.Children.Add((Image)image);

            });

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
