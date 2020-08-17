using System;
using Xunit;
using HashTables.Classes;
using HashTables;
using System.Collections.Generic;

namespace HashTableTesting
{
    public class HashTableTests
    {
        class SimpleObject
        {
            public string StringProp { get; set; }

            public SimpleObject(string value)
            {
                StringProp = value;
            }
        }

        [Fact]
        public void CanAddKeyValuePair()
        {
            //Arrange
            HashTable<int> testHashTable = new HashTable<int>(20);
            string testKey = "our king the key";
            int testValue = 71;

            //Act
            testHashTable.Add(testKey, testValue);

            //Assert
            Assert.NotNull(testHashTable.HashMap);
            bool containsValue = false;
            foreach (LinkedList<KeyValueNode<int>> oneLinkedList in testHashTable.HashMap)
            {
                if (oneLinkedList != null)
                {
                    LinkedListNode<KeyValueNode<int>> currNode = oneLinkedList.First;
                    while (currNode != null)
                    {
                        if (currNode.Value.Value == testValue)
                        {
                            containsValue = true;
                        }
                        currNode = currNode.Next;
                    }
                }
            }
            Assert.True(containsValue);
        }

        [Fact]
        public void CanGetAValueFromAKey()
        {
            //Arrange
            HashTable<int> testHashTable = new HashTable<int>(20);
            string testKey = "our king the key";
            int testValue = 71;

            //Act
            testHashTable.Add(testKey, testValue);
            int gottenValue = testHashTable.Get(testKey);

            //Assert
            Assert.NotNull(testHashTable.HashMap);
            Assert.Equal(testValue, gottenValue);
        }

        [Fact]
        public void ContainsDeterminesWhetherAKeyIsPresent()
        {
            //Arrange
            HashTable<int> testHashTable = new HashTable<int>(20);
            string testKey = "our king the key";
            int testValue = 71;

            //Act
            testHashTable.Add(testKey, testValue);

            //Assert
            Assert.NotNull(testHashTable.HashMap);
            Assert.True(testHashTable.Contains(testKey));
        }

        [Fact]
        public void ReturnsNullForNotPresentValue()
        {
            //Arrange
            HashTable<SimpleObject> testHashTable = new HashTable<SimpleObject>(20);
            string testKey = "our king the key";
            string valueString = "value vroom";
            SimpleObject valueObject = new SimpleObject(valueString);

            string differentKey = "another grike in the clock";

            //Act
            testHashTable.Add(testKey, valueObject);
            SimpleObject gottenValue = testHashTable.Get(differentKey);

            //Assert
            Assert.NotNull(testHashTable.HashMap);
            Assert.Null(gottenValue);
        }

        [Fact]
        public void HandlesCollisions()
        {
            //Arrange
            HashTable<int> testHashTable = new HashTable<int>(20);
            //the strings "2222" and "dd" should be evaluate to a value of 200
            string testKey1 = "2222";
            int testValue1 = 45;
            testHashTable.Add(testKey1, testValue1);

            string testKey2 = "dd";
            int testValue2 = -12;
            testHashTable.Add(testKey2, testValue2);

            //Act
            int gottenValue1 = testHashTable.Get(testKey1);
            int gottenValue2 = testHashTable.Get(testKey2);

            int hashValue1 = testHashTable.GetHash(testKey1);
            int hashValue2 = testHashTable.GetHash(testKey2);

            //Assert
            Assert.NotNull(testHashTable.HashMap);
            Assert.Equal(hashValue1, hashValue2);
            Assert.Equal(2, testHashTable.HashMap[hashValue1].Count);
            Assert.Equal(testValue1, gottenValue1);
            Assert.Equal(testValue2, gottenValue2);
        }

        [Fact]
        public void CanRetrieveValuesFromCollisions()
        {
            //Arrange
            HashTable<int> testHashTable = new HashTable<int>(20);
            //the strings "2222" and "dd" should be evaluate to a value of 200
            string testKey1 = "2222";
            int testValue1 = 45;
            testHashTable.Add(testKey1, testValue1);

            string testKey2 = "dd";
            int testValue2 = -12;
            testHashTable.Add(testKey2, testValue2);

            //Act
            int gottenValue1 = testHashTable.Get(testKey1);
            int gottenValue2 = testHashTable.Get(testKey2);

            //Assert
            Assert.Equal(testValue1, gottenValue1);
            Assert.Equal(testValue2, gottenValue2);
        }

        [Theory]
        [InlineData("some crazy string, but not too long...")]
        [InlineData("&$(*!&*F&uydgo#@198c81vh!7&()$$&G*")]
        [InlineData("Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch")]
        [InlineData("Eyjafjallajökull")]
        [InlineData("846381684351812318461351846581384863")]
        public void HashesAreWithinRange(string testValue)
        {
            //Arrange
            int hashTableSize = 20;
            HashTable<int> testHashTable = new HashTable<int>(hashTableSize);
            //the strings "2222" and "dd" should be evaluate to a value of 200

            //Act
            int index = testHashTable.GetHash(testValue);

            //Assert
            Assert.True(index < hashTableSize);
        }
    }
}
