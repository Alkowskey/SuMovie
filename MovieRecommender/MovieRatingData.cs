using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace SuMovie.Models
{
    public class MovieRating
    {
            [LoadColumn(0)]
            public int Id {get;set;}
            [LoadColumn(1)]
            public int MovieId{get;set;}
            [LoadColumn(2)]
            public int UserId{get;set;}
            [LoadColumn(3)]
            public float Label{get;set;}
            [LoadColumn(4)]
            public String Title{get;set;}
            [LoadColumn(5)]
            public String Rate{get;set;}
            [LoadColumn(6)]
            public int MetaScore{get;set;}
    }

    public class MovieRatingPrediction
    {
        public float Label;
        public float Score;
    }
}