using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverBros2.Objects
{
    public class PostObject
    {
        public string id { get; set; }
        public List<InputValue> values { get; set; }
    }

    public class InputValue
    {
        public string name { get; set; }
        public string data { get; set; }
    }

    public class Question
    {
        public List<InputValue> inputValues { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string data { get; set; }
    }

    public class Answer
    {
        public string challengeId { get; set; }
        public List<Value> values { get; set; }
    }

    public class Example
    {
        public Question question { get; set; }
        public Answer answer { get; set; }
    }

    public class GetChallenge
    {
        public string id { get; set; }
        public string identifier { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Question question { get; set; }
        public Example example { get; set; }
    }


    public class Challenge
    {
        public string status { get; set; }
        public string entry { get; set; }
    }

    public class Overview
    {
        public Challenge challenge01 { get; set; }
        public Challenge challenge02 { get; set; }
        public Challenge challenge03 { get; set; }
        public Challenge challenge04 { get; set; }
        public Challenge challenge05 { get; set; }
        public Challenge challenge06 { get; set; }
        public Challenge challenge07 { get; set; }
        public Challenge challenge08 { get; set; }
        public Challenge challenge09 { get; set; }
        public Challenge challenge10 { get; set; }
        public Challenge challenge11 { get; set; }
        public Challenge challenge12 { get; set; }
        public Challenge challenge13 { get; set; }
        public Challenge challenge14 { get; set; }
        public Challenge challenge15 { get; set; }
        public Challenge challenge16 { get; set; }
        public Challenge challenge17 { get; set; }
        public Challenge challenge18 { get; set; }
        public Challenge challenge19 { get; set; }
        public Challenge challenge20 { get; set; }
    }

    public class PostChallenge
    {
        public string identifier { get; set; }
        public string status { get; set; }
        public string identification { get; set; }
        public Overview overview { get; set; }
    }
}