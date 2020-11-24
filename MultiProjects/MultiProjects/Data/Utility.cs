using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using Xamarin.Forms;

namespace MultiProjects.Data
{
   public static class QuestionData
   {

     
    public static Subject GetQuestions { get; set; }


        
            //implictly invoke once
            //cannot be parameterised
            //static constructor  could be used if dataset wont be changing
        //static QuestionData()
        //{

        //    // var questions = new List<Question>();
        //    //questions.Add(new Question { Title = "Who is the president of United of States ?", Choices = new List<string> { "Boris Johnson", " Donald Trump", " Muhammudu Buhari" },Answer = " Donald Trump" });
        //    //questions.Add(new Question { Title = "Who is the vice president of United of States ?", Choices = new List<string> { " Barack Obama", "Muhammudu Buhari", "Mike Pence" }, Answer = "Mike Pence" });
        //    //questions.Add(new Question { Title = "Who is the prime minister of United Kingdom?", Choices = new List<string> { "Boris Johnson", " Rishi Sunak", "Theresa May" }, Answer = "Boris Johnson" });
        //    //questions.Add(new Question { Title = "Who is the First Minister of Scotland ?", Choices = new List<string> { "Rishi Sunak", " Nicola Sturgeon","Boris Johnson" }, Answer = " Nicola Sturgeon" });
        //    //questions.Add(new Question { Title = "Who is the current leader of the Labour Party ?", Choices = new List<string> { "Sadiq Khan", " Sir Keir Karmer", " Jeremy Corbyn" }, Answer = " Sir Keir Starmer" });
        //    //questions.Add(new Question { Title = "Who is the current leader of the Labour Party ?", Choices = new List<string> { "Sadiq Khan", " Sir Keir Karmer", " Jeremy Corbyn" }, Answer = " Sir Keir Starmer" });
        //   
        //    GetQuestions = PopulateData<Subject>("csharp.json");
        //}

        public static void InitialiseQuestions(string subject)
        {
            GetQuestions = PopulateData<Subject>(subject);
        }


        private static T PopulateData<T>(string fileName)
        {
            var file = "MultiProjects.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T obj;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }

            return obj;
        }


    }


    public class Subject
    {
        public Quiz quiz { get; set; }

        public List<Question> questions { get; set; }

        public void Reset()
        {
            foreach (var q in questions)
            {
                q.Options.ForEach(x => x.IsSelected = false);
                q.IsFlagged = false;
            }
        }
      
    }

    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string Name { get; set; }

        public bool IsAnswer { get; set; }

        public bool IsSelected { get; set; }

    }

    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Option> Options { get; set; }

        public bool IsFlagged { get; set; }

        public bool IsCorrect { get {

               
                if (Options.AsEnumerable().Any(x => x.IsAnswer == true && x.IsSelected == false)){

                    return false;
                }
                if (Options.AsEnumerable().Any(x => x.IsAnswer != x.IsSelected ))
                {
                    return false;
                }
                return true;
            } }
    }
}
