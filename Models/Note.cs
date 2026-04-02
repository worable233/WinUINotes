// 引入基础系统功能（如字符串、日期等）
using System;
// 引入异步任务支持（用于文件操作等耗时任务）
using System.Threading.Tasks;
// 引入Windows存储API（用于访问应用本地存储）
using Windows.Storage;

namespace WinUINotes.Models
{
    public class Note
    {
        // 存储笔记文件的位置
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        // 以下为属性
        public string Filename { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        // 生成唯一文件名：使用"notes"前缀 + 当前时间的二进制表示 + ".txt"后缀
        // DateTime.Now.ToBinary()将当前时间转换为64位整数，确保文件名唯一性
        public Note()
        {
            Filename = "notes" + DateTime.Now.ToBinary().ToString() + ".txt";
        }
        // 保存笔记文件
        public async Task SaveAsync()
        {
            // 尝试获取已存在的笔记文件（如果存在）
            StorageFile noteFile = (StorageFile)await storageFolder.TryGetItemAsync(Filename);
            // 如果文件不存在，则创建新文件
            if (noteFile is null)
            {
                // CreateFileAsync就是创建新文件，ReplaceExisting选项表示如果已存在则替换
                noteFile = await storageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
            }
            // 将笔记文本内容写入文件
            await FileIO.WriteTextAsync(noteFile, Text);
        }
        // 删除该笔记文件
        public async Task DeleteAsync()
        {
            // 尝试获取要删除的笔记文件
            StorageFile noteFile = (StorageFile)await storageFolder.TryGetItemAsync(Filename);
            // 如果文件存在，则执行删除操作
            if (noteFile is not null)
            {
                await noteFile.DeleteAsync();
            }
        }
    }
}