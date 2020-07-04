/* DictionaryTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ksu.Cis300.NameLookup.Tests
{
    /// <summary>
    /// Unit tests for the Dictionary class.
    /// </summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>
        /// Key and values for the dictionary.
        /// </summary>
        private KeyValuePair<int, string>[] _pairs =
        {
            new KeyValuePair<int, string>(10, "Ten"),
            new KeyValuePair<int, string>(5, "Five"),
            new KeyValuePair<int, string>(15, "Fifteen"),
            new KeyValuePair<int, string>(3, "Three"),
            new KeyValuePair<int, string>(7, "Seven"),
            new KeyValuePair<int, string>(13, "Thirteen"),
            new KeyValuePair<int, string>(20, "Twenty")
        };

        /// <summary>
        /// Gets a dictionary containing seven keys and values.
        /// </summary>
        private Dictionary<int, string> LoadDictionary()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> p in _pairs)
            {
                d.Add(p.Key, p.Value);
            }
            return d;
        }

        /// <summary>
        /// Loads a list with one key and value, copies an empty dictionary to it, and verifies
        /// that the list contains its original contents.
        /// </summary>
        [Test]
        public void TestACopyEmpty()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("key", "value"));
            List<KeyValuePair<string, string>> copy = new List<KeyValuePair<string, string>>();
            copy.Add(list[0]);
            d.CopyTo(list);
            Assert.That(list, Is.EquivalentTo(copy));
        }

        /// <summary>
        /// Loads a dictionary with seven keys and values, then copies them to a list, and
        /// verifies that the list contains all the keys and values in order of key.
        /// </summary>
        [Test]
        public void TestBCopyMultiple()
        {
            Dictionary<int, string> d = LoadDictionary();
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            d.CopyTo(list);
            Assert.That(list, Is.EquivalentTo(_pairs).And.Ordered.Ascending.By("Key"));
        }
    }
}