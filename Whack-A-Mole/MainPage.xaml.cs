namespace Whack_A_Mole;

public partial class MainPage : ContentPage
{
    Random _random;

    int life = 0;
    int point;
    
    public MainPage()
    {
        InitializeComponent();
        _random = new Random(); //random class created
        MoveMole(); //Mole will move even without being clicked
        



        Device.StartTimer(new TimeSpan(0, 0, 2), () => //every two seconds this event will run
        {

            //The Mole will move every second
            Device.BeginInvokeOnMainThread(() =>
            {
                life += 10;
                if (life == point) //If the life is equal to the points at each second nothing will happen
                {

                }
                else if(life != point) //Otherwise if the life is not equal to the points at each second this will mean that the user has missed a mole
                {
                    life -= 10; //life variable will decrease by ten in order to prevent the users lives from constantly decreaseing
                    if (Heart1.IsVisible) //If the first heart is visible remove one if life is not equals to point
                    {
                        Heart1.IsVisible = false;
                    }
                    else if (Heart2.IsVisible)
                    {
                        Heart2.IsVisible = false;

                    }
                    else if (Heart3.IsVisible)
                    {
                        Heart3.IsVisible = false;
                        LoseGame();  //"LoseGame()" function will run if no hearts are available
                        LblPoint.Text = point.ToString();
                        point = 0; //point will reset back to 0
                        life = 0; //life will reset back to 0
                        LblPoint.Text = "0"; //point will appear as 0 in the mainpage



                    }

                }
            });
            return true; // runs again, or false to stop
        });






    }




    private void Moleclicked_Clicked(object sender, EventArgs e) //event handler for when the mole is clicked
    {
        Mole.IsVisible = false; //If a mole is clicked the moles will disappear
        Mole2.IsVisible = false;
        Mole2.IsVisible = false;
        Mole3.IsVisible = false;

        point = Convert.ToInt32(LblPoint.Text); //targets the name of the label from the main page and adds it to the int variable by converting it
        point += 10; //the point will increment by 10 if the mole is selected

        LblPoint.Text = point.ToString(); //the incrementation of the point variable will appear in the main page as a string


    }

    private async void LoseGame() //Function that displays a message when the user has no more hearts
    {

        if(Heart1.IsVisible == false && Heart2.IsVisible == false && Heart3.IsVisible == false) //If all the hearts are gone then the event will happen
        { 
        await DisplayAlert("You Lost", "You scored: " + point + " points", "OK"); //
        }
}


    private void MoveMole()
    {




        



        Device.StartTimer(new TimeSpan(0, 0, 2), () => //sets the time frequency in which the mole will move
        {

            //The Mole will move every two second
            Device.BeginInvokeOnMainThread(() =>
            {
                int r = 0; int c = 0;
                r = _random.Next(0, 3); //random row values from 0 - 2
                c = _random.Next(0, 3); //random column values from 0 - 2
                Mole.SetValue(Grid.RowProperty, r); //sets the value of the row from the randomly generated number
                Mole.SetValue(Grid.ColumnProperty, c); //sets the value of the column from the randomly generated number
                Mole.IsVisible = true; //The mole will appear in the random row and column
                int r2 = 0; int c2 = 0;
                r = _random.Next(0, 4); //random row values from 0 - 3 for the moles in grid two
                c = _random.Next(0, 4); //random column values from 0 - 3 for the moles in grid two
                Mole2.SetValue(Grid.RowProperty, r);
                Mole2.SetValue(Grid.ColumnProperty, c);
                Mole2.IsVisible = true;
                int r3 = 0; int c3 = 0;
                r = _random.Next(0, 5); //random row values from 0 - 4 for the moles in grid three
                c = _random.Next(0, 5); //random column values from 0 - 4 for the moles in grid three
                Mole3.SetValue(Grid.RowProperty, r); 
                Mole3.SetValue(Grid.ColumnProperty, c);
                Mole3.IsVisible = true;


                
            });
            
            return true; // runs again, or false to stop
            
        });
        


    }








    private async void NewGame_Clicked(object sender, EventArgs e) //Event handler for when the new game button is clicked
    {
        
        bool answer = await DisplayAlert("Question?", "Do you wish to start a new game", "Yes", "No"); //will display message if the user is sure if they want to select a new game

        if (answer == true) //if the answer is "yes" the game will reset itself
        {
            Grid4x4.IsVisible = false;
            Grid3x3.IsVisible = true; //grid3 will re-appear while the rest of the grids wont
            Grid5x5.IsVisible = false;

            Heart1.IsVisible = true; //all the hearts will re-appear
            Heart2.IsVisible = true;
            Heart3.IsVisible = true;


        }
        else
        {




        }



    }





    private async void NewLayout4x4_Clicked(object sender, EventArgs e)
    {
        bool choice = await DisplayAlert("Question", "Do you wish to proceed, this will wipe your data", "Yes", "No");
        if(choice == true)
        { 

        Grid4x4.IsVisible = true;
        Grid3x3.IsVisible = false;
        Grid5x5.IsVisible = false;

        Heart1.IsVisible = true;
        Heart2.IsVisible = true;
        Heart3.IsVisible = true;

            int point = Convert.ToInt32(LblPoint.Text);
            point = 0;
            life = 0;

            LblPoint.Text = point.ToString();

        }
        else if(choice == false)
        {



        }

    }

    private async void NewLayout5x5_Clicked(object sender, EventArgs e)
    {
        bool choice = await DisplayAlert("Question", "Do you wish to proceed, this will wipe your data", "Yes", "No");
        if (choice == true)
        {
            Grid4x4.IsVisible = false;
            Grid3x3.IsVisible = false;
            Grid5x5.IsVisible = true;

            Heart1.IsVisible = true;
            Heart2.IsVisible = true;
            Heart3.IsVisible = true;

            int point = Convert.ToInt32(LblPoint.Text);
            point = 0;
            life = 0;

            LblPoint.Text = point.ToString();
        }
        else if( choice == false)
        {







        }

    }

    private async void NewLayout3x3_Clicked(object sender, EventArgs e)
    {
        bool choice = await DisplayAlert("Question", "Do you wish to proceed, this will wipe your data", "Yes", "No");
        if (choice == true)
        {
            Grid4x4.IsVisible = false;
            Grid3x3.IsVisible = true;
            Grid5x5.IsVisible = false;


            Heart1.IsVisible = true;
            Heart2.IsVisible = true;
            Heart3.IsVisible = true;

            int point = Convert.ToInt32(LblPoint.Text);
            point = 0;
            life = 0;
            LblPoint.Text = point.ToString();
        }

        else if(choice == false)
        {



        }
    }




}

    

