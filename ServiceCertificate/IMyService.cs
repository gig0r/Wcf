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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IMyService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get?value={value}")]
        string GetData(int value);

        // TODO: Добавьте здесь операции служб

        [OperationContract]
        [WebGet]
        Stream GetFile(int id);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void SetFile(MyFileStream stream);

        [OperationContract]
        [WebInvoke(Method = "DELETE")]
        bool DeleteFile(int id);

    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.

    [DataContract]
    public class MyFileStream
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Stream Data { get; set; }

        public MyFileStream(string name, string desc, Stream data)
        {
            Name = name;
            Description = desc;
            Data = data;
        }
    }
}
