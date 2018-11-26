using System;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceCertificate;

namespace NUnitTestWcfCertificateService
{
    [TestFixture]
    public class WcfServiceTest
    {
        protected ServiceHost _host;
        protected MyService _service;
        private readonly string _patch = Directory.GetCurrentDirectory();

        [OneTimeSetUp]
        protected void Setup()
        {
            _service = new MyService();
            _host = new ServiceHost(typeof(MyService), new Uri("net.pipe://localhost/MyService"));
            _host.Open();
        }

        [TearDown]
        protected void Down()
        {
            _host.Close();
        }

        [Test(Description = "Test metod")]
        public void Tset()
        {
            var result = _service.GetData(1);

            Assert.NotNull(result);
        }

        [Test(Description = "Test get file")]
        public void GetFileTest()
        {
            var response = _service.GetFile(1).Result;

            Assert.NotNull(response);
        }

        [Test(Description = "Test set file")]
        public void SetFileTest()
        {
            Stream stream = File.OpenRead(_patch + "\\test.txt");
            var data = new MyFileStream("test.txt", "My Test file set", stream);
            _service.SetFile(data);

            Assert.NotNull("");
        }

        [Test(Description = "Test delete file by id")]
        public void DeleteFileTest()
        {
            var result = _service.DeleteFile(2);

            Assert.AreEqual(result, true);
        }
    }
}
