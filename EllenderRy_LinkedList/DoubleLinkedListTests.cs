using LinkedListLibrary;

namespace EllenderRy_LinkedList
{
    public class DoubleLinkedListTests
    {
        #region Void Return Tests (Add, Insert, and Clear)
        [Fact]
        public void DoubleLinkedListAddInt()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            string expected = "1, 2, 3";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void DoubleLinkedListAddChar()
        {
            DoubleLinkedList<char> list = new DoubleLinkedList<char>();
            list.Add('a');
            list.Add('k');
            list.Add('w');
            list.Add('p');

            string expected = "a, k, w, p";
            Assert.Equal(expected, list.ToString());
        }

        [Fact]
        public void DoubleLinkedListInsertMiddle()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Insert(4, 2);
            string expected = "1, 2, 4, 3, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void DoubleLinkedListInsertBeginning()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Insert(4, 0);
            string expected = "4, 1, 2, 3, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void DoubleLinkedListInsertEnd()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Insert(4, 3);
            string expected = "1, 2, 3, 4, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void DoubleLinkedListClear()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Clear();
            string expected = "";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void DoubleLinkedListClearNothing()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            
            list.Clear();
            string expected = "";
            Assert.Equal(expected, list.ToString());
        }
        #endregion

        #region Remove Tests
        [Fact]
        public void DoubleLinkedListRemoveCheckString()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.Remove();
            string expected = "2, 3, 5";
            Assert.Equal(expected, list.ToString());
        }
        [Fact]
        public void DoubleLinkedListRemoveCheckData()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = list.Remove().Data;
            Assert.Equal(1, expected);
        }
        [Fact]
        public void DoubleLinkedListRemoveAtCheckString()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.RemoveAt(2);
            string expected = "1, 2, 5";
            Assert.Equal(expected, list.ToString());
        }

        [Fact]
        public void DoubleLinkedListRemoveAtCheckData()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            Assert.Equal(3, list.RemoveAt(2).Data);
        }
        [Fact]
        public void DoubleLinkedListRemoveLastCheckString()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list.RemoveLast();
            string expected = "1, 2, 3";
            Assert.Equal(expected, list.ToString());
        }
        
        [Fact]
        public void DoubleLinkedListRemoveLastCheckData()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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
        public void DoubleLinkedListGetData()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = list.Get(1).Data;
            Assert.Equal(2, expected);
        }
        [Fact]
        public void DoubleLinkedListGetException()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void DoubleLinkedListSearch()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            int expected = 2;
            Assert.Equal(expected, list.Search(3));
        }
        [Fact]
        public void DoubleLinkedListSearchDuplicates()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(9);
            list.Add(2);
            list.Add(4);
            list.Add(3);
            list.Add(5);

            int expected = 1;
            Assert.Equal(expected, list.Search(2));
        }
        [Fact]
        public void DoubleLinkedListSearchFail()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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