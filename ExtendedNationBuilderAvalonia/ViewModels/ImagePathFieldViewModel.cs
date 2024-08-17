using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using ExtendedNationBuilderAvalonia.Views.Dialog;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilderAvalonia.ViewModels
{
    public class ImagePathFieldViewModel : ViewModelBase
    {
        [Reactive]
        public string? Path { get; set; }

        public string Watermark { get; }

        public ImagePathFieldViewModel(Window owner, string watermark) : base(owner)
        {
            Watermark = watermark;
        }

        public async void BrowseExplorer()
        {
            var file = await Owner.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Choose the image",
                FileTypeFilter = new[] { FilePickerFileTypes.ImagePng, FilePickerFileTypes.ImageJpg },
                AllowMultiple = false,
            });

            if (file.Count > 0)
            {
                string path = file[0].Path.LocalPath;

                Bitmap image = new Bitmap(path);
                if (image.Size.Width != 256 && image.Size.Height != 128) 
                {
                    await new OkDialog("Warning", "Image size should be 256x128").ShowDialog(Owner);
                    return;
                }


                Path = path;
            }

        }
    }
}
