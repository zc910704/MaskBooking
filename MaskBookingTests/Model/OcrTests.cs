using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaskBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskBooking.Model.Tests
{
    [TestClass()]
    public class OcrTests
    {
        //ocr测试
        [TestMethod()]
        public void GetOcrResultTest()
        {
            const string testData = @"/9j/4AAQSkZJRgABAgAAAQABAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0a
                                      HBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIy
                                      MjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAAlAFYDASIA
                                      AhEBAxEB/8QAHwAAAQUBAQEBAQAAAAAAAAAAAAACAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQA
                                      AAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3
                                      ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWm
                                      p6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEA
                                      AwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSEx
                                      BhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElK
                                      U1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3
                                      uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD1jYXg
                                      CSHLFQCw9fUVFE86gAoJAPlIBwyn8eo6Y74NSu7rkhMgEdOcjv8AiKgUTm5aRdrpyFycDBC9Ouf/
                                      ANdZHKEV6hCpI6q4BD7iBhhgU6S4RnUQyKzD+6d36d+nbn86pXV3c29vGbewe5uPPZREJAgBILcs
                                      RjGCefXHrWcmrXt3q66bfWJ0+WZCYv3m8SAckZXjIGePr7ZlySdilFvU3YJxcxhBNiVRltmOffkf
                                      /qp0Cy7c+cWG9gQ4zwGPTGK5PWdX1nT7u9lXQzcQW8e77Ul2sRwBknbgnseOuBkcVoaPf3F/oSX0
                                      9q4IiNx9nAExIOSoHTLMMEfXHHOXzLYHF2ub0koWTypCo8wYTIyD6g/571UdgkgIieIoh3DJwvTk
                                      YBGOD27c1g3euahYCOfUvDv2KzDbHmS4WUIWIwWVRnHGD9cdcA62sX01jpPmrp91dTuxijjg+YqS
                                      Dy7HG1OMFuex560oyUthWLsXlzPkuWYYKScBh1GOOvQ+1VkvmDKTcBgfVRx6kj+mc/XvU0HUk8R6
                                      dZaukP2aSXfuiD7iACyg5wM9PTvjtV+7iDr5qI+5VxK3yg4xyD7+47HvVBazsXYJPMj3CRH91GP6
                                      0VWtR5YDrbOQyjaw2jj0xnj/ADn1ooESO1yXkRGjDAgrkEcfr6EVBFJeIQmxNgzkqpOz2xn3H4dM
                                      1bmBXbKqlmTqo6kHr/Q/hUU+ConjkKtjAGfvkchceufx6igCrdXdh9ieO7vUhW6JjEn+rwdp5BPQ
                                      /KcHpketczFa248W2QsNRbVS8DiVrh/O8lQDg7x0yTj2z/tCuteKO4i2XSxtG/LBwGSQDnntnjP5
                                      HtgJFaw6asj21lbRoeX8lBGSB6gDnHPes5RbaLjKyOQ8ZTXI06GwWVEutSmS0R3fYVGcMSRnK/wn
                                      vg++D0cTw6PbIu1re3s4QrKTnMajqOpOACe/fnJObht7EzLcTxRearN5bSoNyZGG2k+vcjr06Cp2
                                      MH2dSzRuuNoaRhhvx/CqtrcTeljz/wAT/wBnFftdtrcmoXIu1lisHuBcQyEt90Iv3Rg9+3HOc121
                                      1f2dhDKt9cR20DSGMSyuFBZhuxk9+T+Aqlb2Om2eoxzWWnW0cpzkCNFZc8ZU9s5PGeR7VZutL0/U
                                      UWG4hSSJj5ghlQMocZHIPQ8kYGOhqYQ5W2+ojnfh3qFi/hCysZLm3a4iWWQxLIC6r5jckZyDzn6E
                                      V1ufKdZFZ3VvlI2k4Az1x6fn1z7ZEOjadpdyZLewhtJHTb5lvGFYHvjHJXj6/TirMMrC3YCQsShJ
                                      RlwGGMfpj19+xFavVjlq7mlbyROgERYryQSpA69AcUVDEn2qPLF45AcM8eV3Y454H/1qKRJHePFZ
                                      lNsC/Nn7h2EY9x9aznupHDAYAb7wyTn8yfSiigaHm+drM27qCMABumMGtK0uvt0ciPGBgANg9c5o
                                      ooBkwBhaMbt284bjHOCc/jjp/kw+VCbVbmSFGcR7zxjccZOaKKBEU0a28g8sbSgzleMjDHB9fu/4
                                      5ouJPKt7e6wDIdu7tu4//WPxNFFACagshikUyApGFblRk5OOv4dqpRy71aE7jHtZgGIOCBxzj0AH
                                      +cUUUDRP+7tdzvEknzYIxjuR74+6fz9qKKKAP//Z";
            MaskBooking r = new MaskBooking();
            //string s = r.TouchCaptchaString(testData);
            //var real = r.GetOcrResult(s);
            var expect = "3731";
            //Assert.AreEqual(expect, real);
        }
    }
}