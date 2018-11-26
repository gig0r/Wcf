using MyDataEntityLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceCertificate
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class MyService : IMyService
    {
        private FileManager _fileManager;

        public MyService()
        {
            _fileManager = new FileManager(new MyDataEntityLibrary.Data.FileDbContext());
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Stream GetFile(int id)
        {
            return _fileManager.Download(id);
        }

        public void SetFile(MyFileStream stream)
        {
            _fileManager.Upload(stream.Name, stream.Description, stream.Data);
        }

        public bool DeleteFile(int id)
        {
            return _fileManager.Delete(id);
        }

    }
}
