using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.EntityFrameworkCore;

using SuMovie.Models;
using SuMovie.Context;

using System.Data.SqlClient;

namespace SuMovie
{
    public interface IMovieRecommender
    {
        (IDataView training, IDataView test) LoadData();
        ITransformer BuildAndTrainModel(IDataView trainingDataView);
        void EvaluateModel(IDataView testDataView);
        bool UseModelForSinglePrediction(int uId, int mId);
        void SaveModel(DataViewSchema trainingDataViewSchema, ITransformer model);
        
    }
    public class MovieRecommender : IMovieRecommender
    {
        private MLContext mlContext;

        private ITransformer model;

        private DataViewSchema modelSchema;

        public MovieRecommender()
        {

            mlContext = new MLContext();

            (IDataView trainingDataView, IDataView testDataView) = LoadData();

            model = mlContext.Model.Load(Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip"), out modelSchema);

            //Model trained

            /*model = BuildAndTrainModel(trainingDataView);

            EvaluateModel(testDataView);

            UseModelForSinglePrediction(1, 49);

            SaveModel(trainingDataView.Schema, model);*/
        }
        
        public (IDataView training, IDataView test) LoadData()
        {
            var trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train2.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-test.csv");
            
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<MovieRating>(trainDataPath, hasHeader: false, separatorChar: ',');

            IDataView testDataView = mlContext.Data.LoadFromTextFile<MovieRating>(testDataPath, hasHeader: false, separatorChar: ',');

            return (trainingDataView, testDataView);

        }

        public ITransformer BuildAndTrainModel(IDataView trainingDataView)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "UserId")
                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "MovieId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;

        }

        public void EvaluateModel(IDataView testDataView)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);

            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());

        }

        public bool UseModelForSinglePrediction(int uId, int mId)
        {
            Console.WriteLine("=============== Making a prediction ===============");
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(model);

            var testInput = new MovieRating { UserId = uId, MovieId = mId };

            var movieRatingPrediction = predictionEngine.Predict(testInput);

            if (Math.Round(movieRatingPrediction.Score, 1) > 3.5)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void SaveModel(DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");

            Console.WriteLine("=============== Saving the model to a file ===============");
            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);

        }

    }
}
