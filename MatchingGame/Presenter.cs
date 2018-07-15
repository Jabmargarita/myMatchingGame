using MatchingGame;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{ 
  class Presenter
    {

        //collection
        public ObservableCollection<PictureModel> AllPictures { get; private set; }

        //create all pictures-looks ugly but who cares

        public void CreatePictures()
        {
            AllPictures = new ObservableCollection<PictureModel>();
            PictureModel Picture1 = new PictureModel { Id = 0, ImageSource = "/Images/Domas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture1Match = new PictureModel { Id = 0, ImageSource = "/Images/Domas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture2 = new PictureModel { Id = 1, ImageSource = "/Images/Evelina.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture2Match = new PictureModel { Id = 1, ImageSource = "/Images/Evelina.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture3 = new PictureModel { Id = 2, ImageSource = "/Images/Gustas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture3Match = new PictureModel { Id = 2, ImageSource = "/Images/Gustas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture4 = new PictureModel { Id = 3, ImageSource = "/Images/Karolis.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture4Match = new PictureModel { Id = 3, ImageSource = "/Images/Karolis.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture5 = new PictureModel { Id = 4, ImageSource = "/Images/Margarita.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture5Match = new PictureModel { Id = 4, ImageSource = "/Images/Margarita.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture6 = new PictureModel { Id = 5, ImageSource = "/Images/Mindaugas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture6Match = new PictureModel { Id = 5, ImageSource = "/Images/Mindaugas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture7 = new PictureModel { Id = 6, ImageSource = "/Images/Pavel.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture7Match = new PictureModel { Id = 6, ImageSource = "/Images/Pavel.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture8 = new PictureModel { Id = 7, ImageSource = "/Images/Povilas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture8Match = new PictureModel { Id = 7, ImageSource = "/Images/Povilas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture9 = new PictureModel { Id = 8, ImageSource = "/Images/Vidas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture9Match = new PictureModel { Id = 8, ImageSource = "/Images/Vidas.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture10 = new PictureModel { Id = 9, ImageSource = "/Images/Vladimir.jpg", IsMatched = false, IsOpen = false };
            PictureModel Picture10Match = new PictureModel { Id = 9, ImageSource = "/Images/Vladimir.jpg", IsMatched = false, IsOpen = false };

            AllPictures.Add(Picture1);
            AllPictures.Add(Picture1Match);
            AllPictures.Add(Picture2);
            AllPictures.Add(Picture2Match);
            AllPictures.Add(Picture3);
            AllPictures.Add(Picture3Match);
            AllPictures.Add(Picture4);
            AllPictures.Add(Picture4Match);
            AllPictures.Add(Picture5);
            AllPictures.Add(Picture5Match);
            AllPictures.Add(Picture6);
            AllPictures.Add(Picture6Match);
            AllPictures.Add(Picture7);
            AllPictures.Add(Picture7Match);
            AllPictures.Add(Picture8);
            AllPictures.Add(Picture8Match);
            AllPictures.Add(Picture9);
            AllPictures.Add(Picture9Match);
            AllPictures.Add(Picture10);
            AllPictures.Add(Picture10Match);

            Shuffle<PictureModel>(AllPictures);

            foreach (PictureModel myPicture in AllPictures)
                {

                PictureToShow(myPicture);
            }

        }


        //shuffle pictures to have a random place in the list
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }






        //selected pictures for matching
        private PictureModel SelectedPicture1;
        private PictureModel SelectedPicture2;

        //select a picture to be matched
        public void SelectSlide(PictureModel pictureToBeMatched)
        {
            if (SelectedPicture1 == null)
            {
                SelectedPicture1 = pictureToBeMatched;
                pictureToBeMatched.IsOpen = true;
                CanSelect(pictureToBeMatched);
            }
            else if (SelectedPicture2 == null)
            {
                SelectedPicture2 = pictureToBeMatched;
                pictureToBeMatched.IsOpen = true;
                CanSelect(pictureToBeMatched);
            }
        }

        //clear selected
        public void ClearSelected()
        {
            SelectedPicture1 = null;
            SelectedPicture2 = null;

        }

        //check if it's a match

        public bool CheckIfMatched()
        {
            if (SelectedPicture1.Id == SelectedPicture2.Id)
            {
                MatchCorrect();
                return true;
            }
            else
            {
                MatchFailed();
                return false;
            }
        }


        
        private void MatchCorrect()

        {
            SelectedPicture1.IsMatched = true;
            SelectedPicture2.IsMatched = true;
            CanSelect(SelectedPicture1);
            CanSelect(SelectedPicture2);

        }

        private void MatchFailed()
        {
            CanSelect(SelectedPicture1);
            CanSelect(SelectedPicture2);

        }

        //nmegalima pasirinkt
        private bool CanSelect(PictureModel picture)
        {
            if (picture.IsOpen)
            {
                return false;
            }
            else if (picture.IsMatched)
            {
                return false;
            }
            else return true;
        }


        //picture to be shown-kaip cia sugalvojus geriau?

        public string PictureToShow (PictureModel picture)
        {
          if (picture.IsMatched ==true)
            {
                return picture.ImageSource = picture.ImageSource;

            } else if (picture.IsOpen == true)
            {
               return picture.ImageSource = picture.ImageSource;
            } else
            {
                return picture.ImageSource = "/Images/back.jpg";
            }
        }


    
    }


}

