using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
// ↓ 添加了这些内容 ↓
using WinUINotes.Models;
// ↑ 添加了这些内容 ↑

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUINotes.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotePage : Page
    {

        private Note? noteModel;

        public NotePage()
        {
            this.InitializeComponent();
            // ↓ 之前的内容是存在的，只需要添加这一行即可 ↓
            Loaded += NotePage_Loaded;
            // ↑ 之前的内容是存在的，只需要添加这一行即可 ↑
        }


        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (noteModel is not null)
            {
                await noteModel.SaveAsync();
            }
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (noteModel is not null)
            {
                await noteModel.DeleteAsync();
            }
        }
    }
}
