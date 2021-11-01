using NUnit.Framework;
using ClosedList;
namespace CircleClosedList
{
    public class TestWithEmptyCollection
    {
        CircleClosedList<string> ccl;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Add()
        {
             ccl = new CircleClosedList<string>();
            ccl.Add("2");
            ccl.Add("3");
            ccl.Add("4");
           
            Assert.AreEqual(3, ccl.Count);
        }
        
    }
    public class TestsCircleCollection
    {
        int eventCount = 0;
        CircleClosedList<string> ccl;
        [SetUp]
        public void Setup()
        {
            ccl = new CircleClosedList<string>();
            ccl.Add("2");
            ccl.Add("3");
            ccl.Add("4");
        }

        [Test]
        public void indexGet()
        {
            ccl = new CircleClosedList<string>();
            ccl.Add("2");
            ccl.Add("3");
            ccl.Add("4");

            Assert.AreEqual("3", ccl[1]);
        }
        [Test]
        public void Head()
        {         
            Assert.AreEqual("2", ccl.Head);
        }
        [Test]
        public void Curren()
        {
            Assert.AreEqual("2", ccl.Current);
        }
        [Test]
        public void Next()
        {
            var data = ccl.Next;
            Assert.AreEqual("3", data);
        }
        [Test]
        public void Forward()
        {
            var data = ccl.Previous;
            Assert.AreEqual("4", data);
        }

        [Test]
        public void Contains()
        {
            var res = ccl.Contains("3");
            Assert.AreEqual(true,res);
        }
        [Test]
        public void IndexOf()
        {
            var res = ccl.IndexOf("4");
            Assert.AreEqual(2, res);
        }
        [Test]
        public void MoveNext()
        {
            ccl.MoveNext();
            Assert.AreEqual("3", ccl.Current);
        }
        [Test]
        public void MoveBack()
        {
            ccl.MoveBack();
            Assert.AreEqual("4", ccl.Current);
        }
        [Test]
        public void Remove()
        {
            ccl.Remove("2");
            var res = ccl.Contains("2");
            Assert.False(res);
        }
        [Test]
        public void RemoveAt()
        {
            ccl.RemoveAt(1);
            var res = ccl.Contains("3");
            Assert.False(res);
        }

        [Test]
        public void Insert()
        {
            ccl.Insert(2,"5");
            
            Assert.AreEqual("5", ccl[2]);
            Assert.AreEqual("3", ccl[1]);
            Assert.AreEqual("4", ccl[3]);
        }
        [Test]
        public void CopyTo()
        {
            string[] arr = new string[7];
            ccl.CopyTo(arr, 2);

            Assert.AreEqual("2", arr[2]);
            Assert.AreEqual("3", arr[3]);
            Assert.AreEqual("4", arr[4]);
        }
       
        [Test]
        public void EventNext()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count<10)
            {
                ccl.MoveNext();
                count++;
            }

            Assert.AreEqual(3, eventCount);

        }
        [Test]
        public void EventBack()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count < 10)
            {
                ccl.MoveBack();
                count++;
            }
            Assert.AreEqual(3, eventCount);
        }
        [Test]
        public void ClearL()
        {
            ccl.Clear();
            ccl.Add("7");
            Assert.AreEqual("7", ccl.Current);
            Assert.AreEqual(1, ccl.Count);
        }
        private void DoSomething(object sender, string e)
        {
            eventCount++;
        }
    }
}