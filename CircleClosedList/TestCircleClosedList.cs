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
        [Test]
        public void MoveAndGetCurrentAndHead()
        {
            ccl = new CircleClosedList<string>();
            var resC = ccl.Current;
            ccl.MoveNext();
            var resH = ccl.Head;
            ccl.MoveBack();

            Assert.Null(resH);
            Assert.Null(resC);
        }

    }
    public class TestsCircleCollection
    {
        int eventCount = 0;

        private void DoSomething(object sender, string e)
        {
            eventCount++;
        }

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
        public void ClearL()
        {
            ccl.Clear();
            ccl.Add("7");
            Assert.AreEqual("7", ccl.Current);
            Assert.AreEqual(1, ccl.Count);
        }

        [Test]
        public void Clear()
        {
            ccl.Clear();
            Assert.IsNull(ccl.Head);
        }

        [Test]
        public void InvokeAfterRemove()
        {
            ccl.RemoveAt(0);

            Assert.AreEqual("3", ccl.Head);
            Assert.AreEqual("3", ccl.Current);
        }

        [Test]
        public void InvokeAfterRemove1()
        {
            ccl.RemoveAt(1);

            Assert.AreEqual("2", ccl.Head);
            Assert.AreEqual("2", ccl.Current);
            Assert.AreEqual("4", ccl.Next);

            ccl.MoveNext();
            Assert.AreEqual("4", ccl.Current);
        }

        [Test]
        public void MoveNextWithNegative()
        {
            ccl.MoveNext(-1);
            Assert.AreEqual("4", ccl.Current);
        }

        [Test]
        public void MoveBackWithNegative()
        {
            ccl.MoveBack(-1);
            Assert.AreEqual("3", ccl.Current);
        }

        [Test]
        public void EventNext()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count < 10)
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
        public void EventNextWithNegative()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count < 10)
            {
                ccl.MoveNext(-1);
                count++;
            }

            Assert.AreEqual(3, eventCount);
        }

        [Test]
        public void EventBackWithNegative()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count < 10)
            {
                ccl.MoveBack(-1);
                count++;
            }
            Assert.AreEqual(3, eventCount);
        }

        [Test]
        public void EventNextThenBackWithNegative()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count < 10)
            {
                ccl.MoveNext(-1);
                count++;
            }
            while (count > 0)
            {
                ccl.MoveBack(-1);
                count--;
            }

            Assert.AreEqual(7, eventCount);
        }

        [Test]
        public void EventNextThenBack()
        {
            eventCount = 0;
            ccl.HeadReached += DoSomething;
            int count = 0;
            while (count < 10)
            {
                ccl.MoveBack();
                count++;
            }
            while (count > 0)
            {
                ccl.MoveBack();
                count--;
            }
            Assert.AreEqual(6, eventCount);
        }
    }
}