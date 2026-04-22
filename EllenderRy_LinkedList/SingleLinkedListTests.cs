using LinkedListLibrary;

namespace EllenderRy_LinkedList
{
    public class SingleLinkedListTests
    {
        #region Void Return Tests (Add, Insert, and Clear)
        [Fact]
        public void SingleLinkedListAddInt()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            string expected = "1, 2, 3";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void SingleLinkedListAddChar()
        {
            SingleLinkedList<char> list = new SingleLinkedList<char>();
            list.Add('a');
            list.Add('k');
            list.Add('w');
            list.Add('p');

            string expected = "a, k, w, p";
            Assert.Equal(expected, list.ToString());
        }

        [Fact]
        public void SingleLinkedListInsertMiddle()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Insert(4, 2);
            string expected = "1, 2, 4, 3, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        
        public void SingleLinkedListInsertBeginning()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Insert(4, 0);
            string expected = "4, 1, 2, 3, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void SingleLinkedListClear()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Clear();
            string expected = "";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void SingleLinkedListClearNothing()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            
            list.Clear();
            string expected = "";
            Assert.Equal(expected, list.ToString());
        }
        #endregion

        #region Remove Tests
        [Fact]
        public void SingleLinkedListRemoveCheckString()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Remove();
            string expected = "2, 3, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void SingleLinkedListRemoveCheckData()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = list.Remove().Data;
            Assert.Equal(1, expected);
        }
        [Fact]
        public void SingleLinkedListRemoveAtCheckString()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.RemoveAt(2);
            string expected = "1, 2, 5";
            Assert.Equal(expected, list.ToString());
        }

        [Fact]
        public void SingleLinkedListRemoveAtCheckData()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            Assert.Equal(3, list.RemoveAt(2).Data);
        }
        [Fact]
        public void SingleLinkedListRemoveLastCheckString()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.RemoveLast();
            string expected = "1, 2, 3";
            Assert.Equal(expected, list.ToString());
        }
        
        [Fact]
        public void SingleLinkedListRemoveLastCheckData()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = list.RemoveLast().Data;
            Assert.Equal(5, expected);
        }
        #endregion

        #region Value Return Tests (Get and Search)
        [Fact]
        public void SingleLinkedListGetData()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = list.Get(1).Data;
            Assert.Equal(2, expected);
        }
        [Fact]
        public void SingleLinkedListGetException()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void SingleLinkedListSearch()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = 2;
            Assert.Equal(expected, list.Search(3));
        }
        [Fact]
        public void SingleLinkedListSearchFail()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = -1;
            Assert.Equal(expected, list.Search(4));
        }
        #endregion
    }
}