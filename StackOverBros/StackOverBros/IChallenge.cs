using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverBros
{
    public interface IChallenge
    {
        string identifier { get; set; }
        string status { get; set; }
        string identification { get; set; }
        IOverview overview { get; set; }
    }

    public interface IOverview
    {
        ISupChallenge challenge01 { get; set; }
        ISupChallenge challenge02 { get; set; }
        ISupChallenge challenge03 { get; set; }
        ISupChallenge challenge04 { get; set; }
        ISupChallenge challenge05 { get; set; }
        ISupChallenge challenge06 { get; set; }
        ISupChallenge challenge07 { get; set; }
        ISupChallenge challenge08 { get; set; }
        ISupChallenge challenge09 { get; set; }
        ISupChallenge challenge10 { get; set; }
        ISupChallenge challenge11 { get; set; }
        ISupChallenge challenge12 { get; set; }
        ISupChallenge challenge13 { get; set; }
        ISupChallenge challenge14 { get; set; }
        ISupChallenge challenge15 { get; set; }
        ISupChallenge challenge16 { get; set; }
        ISupChallenge challenge17 { get; set; }
        ISupChallenge challenge18 { get; set; }
        ISupChallenge challenge19 { get; set; }
        ISupChallenge challenge20 { get; set; }
    }

    public interface ISupChallenge
    {
        string status { get; set; }
        string entry { get; set; }
    }
}
