using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MongoDBDemo
{
    [TestClass]
    public class UnitTest1
    {
        public class Trip
        {
            public string Country { get; set; }
            public string City { get; set; }
            public DateTime Date { get; set; }
            public List<Line> Lines { get; set; }
        }

        public class Line
        {
            public List<string> ScenicSpot { get; set; }
            public string Hotel { get; set; }
        }

        [TestMethod]
        public void TestCreate()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("test");
            var collection = database.CreateCollection("");
        }

        [TestMethod]
        public void TestAdd()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<Trip>("");

            collection.InsertOne<Trip>(new Trip
            {

            });
        }
    }
}
