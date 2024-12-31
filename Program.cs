#nullable disable
using System.Net;//used for bitcoin price
using Newtonsoft.Json;//used for converting bitcoin price to jsom
TV bigtv = new TV();//my tv object

//created menu for big tv
bool loop=true;//used loop for contnisuly showing the menu
while(loop){
    Console.WriteLine("1.Turn on TV");
    Console.WriteLine("2.Exit");
    string selectionbyuser=Console.ReadLine();
    if(selectionbyuser == "1"){
        bigtv.TurnOn();
        OnTvMENU();//performing function to optimize the code for goodlooking code
    }
    else if(selectionbyuser == "2"){
        loop=false;//exiting for lop exiting program
    }
    else{//if user enter option other than 1,2
        Console.WriteLine("Invalid value entered by the user");
    }


}

void OnTvMENU(){
    bool firstloop=true;
    while(firstloop){
        Console.WriteLine("1 Increase the volume of bigtv");
        Console.WriteLine("2 Decrease the volume of bigtv");
        Console.WriteLine("3 Increase the Brightness of bigtv");
        Console.WriteLine("4 decrease the Brightness of bigtv");
        Console.WriteLine("5 Connect bigtv to Bluetooth");
        Console.WriteLine("6 Connect bigtv to WIFI");
        Console.WriteLine("7 change contast setting");
        Console.WriteLine("8 Change channel");
        Console.WriteLine("9 Display Current Settings");
        Console.WriteLine("10 Open installed App in big tv");
        Console.WriteLine("11 Change picture quality");
        Console.WriteLine("12 Check Bitcoin Prices online ");
        Console.WriteLine("13 Disconnect From Bluetooth");
        Console.WriteLine("14 Disconnect From Wifi");
        Console.WriteLine("15 Change Language setting of tv");
        Console.WriteLine("16 turnoff bigtv");
        string userselection=Console.ReadLine();


        if(userselection == "1"){
            bigtv.Increasevolume();
        }

        else if(userselection == "2"){
            bigtv.Decreasevolume();
        }

        else if(userselection == "3"){
            bigtv.IncreaseBrightness();
        }

        else if(userselection == "4"){
            bigtv.DecreaseBrightness();
        }

        else if(userselection == "5"){
            bigtv.ConnectToBluetooth();
        }

        else if(userselection == "6"){
            bigtv.ConnectToWifi();
        }

        else if(userselection == "7"){
            Console.WriteLine("Enter contrast value:");
            try{//checking if user enters a string value
                int contrastValue = int.Parse(Console.ReadLine());
                bigtv.SetContrast(contrastValue);
            }
            catch{//giving message if user enters string instead of number
                Console.WriteLine("Please enter a valid number from 0 to 100");
            }
            
        }

        else if(userselection == "8"){
            Console.WriteLine("Enter channel number:");
            try{
                int channel = int.Parse(Console.ReadLine());
                bigtv.SetChannel(channel);
            }
            catch{// if user eneters a string instead of integer
                Console.WriteLine("Please enter a integer");
            }

        }

        else if(userselection == "9"){
            bigtv.DisplayCurrentSettings();
        }

        else if(userselection == "10"){
            bigtv.OpenApp();
        }

        else if(userselection == "11"){
            Console.WriteLine("Please enter Clearity 180p,240p,480p,HD,HDR ");
            string userclarity=Console.ReadLine();
            bigtv.ChooseClarity(userclarity);
        }
        else if(userselection == "12"){
            bigtv.CheckBitcoinPrices();//used web client for bitcoin prices
        }

        else if(userselection == "13"){
            bigtv.DisconnectFromBluetooth();
        }

        else if(userselection == "14"){
            bigtv.DisconnectFromWifi();
        }

        else if(userselection == "15"){
            bigtv.SelectLanguage();
        }
        else if(userselection == "16"){
            bigtv.TurnOff();
            firstloop = false;
        }
        else{
            Console.WriteLine("Invalid Input");
        }
    }
}


class TV
{
    public bool Power;
    public int Volume;
    public string Wireless;//if wireless value is wifi then wifi connected, if not then wifi not connected
    public string Connectivity;//if connectivity value is bluetooth then bluetooth connected ,if not then bluetooth not connected
    public string Clarity;
    public int Channel;
    public int Brightness;
    public int Contrast;
    public string Input;
    public string CurrentLanguage;


    public TV(){//automatic setting for tv
        this.Clarity="HDR";
        this.Volume=10;
        this.Brightness=40;
        this.Contrast=10;
        this.CurrentLanguage = "English";
    }    


    public void TurnOn()//setting power to true
    {
        Power = true;
        Console.WriteLine("TV is now turned on.");
    }

    public void TurnOff()//setting power to false
    {
        Power = false;
        Console.WriteLine("TV is now turned off.");
    }

    public void Increasevolume()
    {
        if (Power)
        {
            if (Volume < 100)//volume can be maximum increase to 100
            {
                Volume++;
                Console.WriteLine("Volume increased to: " + Volume);
            }
            else
            {
                Console.WriteLine("Volume is already at maximum.");
            }
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

    public void Decreasevolume()
    {
        if (Power)
        {
            if (Volume > 0)//volume can be minimum be 0
            {
                Volume--;
                Console.WriteLine("Volume decreased to: " + Volume);
            }
            else
            {
                Console.WriteLine("Volume is already at minimum.");
            }
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

  public void ConnectToBluetooth()//connecting ot bluetooth setting the conectivity to bluetooth
    {
        if (Power)
        {
            if(Connectivity == "Bluetooth")
            {
                Console.WriteLine("TV is already connected to Bluetooth.");
            }
            else
            {
                Connectivity = "Bluetooth";
                Console.WriteLine("TV is now connected to Bluetooth.");
            }
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

    public void ConnectToWifi()
    {
        if (Power)//connecting to wifi setting wireless to wifi
        {
            if(Wireless == "WIFI")
            {
                Console.WriteLine("TV is already connected to WIFI.");
            }
            else
            {
                Wireless = "WIFI";//if already is set to wifi
                Console.WriteLine("TV is now connected to WIFI.");
            }
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

    public void ChooseClarity(string ClarityOption)
    {
        if (Power)
        {//user can change the clarity of the TV
            if(ClarityOption == "HD"  || ClarityOption == "HDR"  ||ClarityOption == "480p"  || ClarityOption == "180p"  ||ClarityOption == "240p" ){
                Clarity = ClarityOption;
                Console.WriteLine("TV Clarity set to: " + Clarity);
            }
            else{
                Console.WriteLine("Please choose between 180p,240p,480p,HD,HDR");
            }

        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }
    
    
    public void IncreaseBrightness()
    {
        if (Power)
        {//if tv is on brightness will increase
            Brightness++;
            Console.WriteLine("TV Brightness increased to "+Brightness);
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }
    
    
    public void DecreaseBrightness()
    {
        if (Power)
        {//if tv is on brightness will decrease
            Brightness--;
            Console.WriteLine("TV Brightness decreased to "+Brightness);
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }
    
    

    public void SetContrast(int contrast){

        if (Power)
        {//setting contrast value if the value is between 0 to 100
            if (contrast >= 0 && contrast <= 100)
            {
                this.Contrast = contrast;
                Console.WriteLine("TV Contrast set to: " + Contrast);
            }
            else
            {
                Console.WriteLine("Please enter a valid number between 0 to 100");
            }
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
        

    }
    
    
    public void SetChannel(int Channel)
    {
        if (Power)
        {//setting channel of the TV
            this.Channel = Channel;
            Console.WriteLine("TV Channel set to: " + Channel);
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

    

    public void DisplayCurrentSettings()
    {
        if (Power)
        {//displaying TV majour settings
            Console.WriteLine("Current TV settings: ");
            Console.WriteLine(" Volume: " + Volume);
            Console.WriteLine(" Wireless: " + Wireless);
            Console.WriteLine(" Clarity: " + Clarity);
            Console.WriteLine(" Brightness: " + Brightness);
            Console.WriteLine(" Contrast: " + Contrast);
            Console.WriteLine(" Current Language: " + CurrentLanguage);
            Console.WriteLine(" Connectivity: " + Connectivity);
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

        
    public void OpenApp()
    {
        bool loop = true;
        while(loop)
        {//if user want to open apps 2 options netflix and amazon prime 
            Console.WriteLine("1.Netflix");
            Console.WriteLine("2.Amazon Prime");
            Console.WriteLine("3.Exit");
            string usrinput = Console.ReadLine();
            
            if(usrinput == "1")
            {//if user want to open netflx app
                PerformNetflixAppOpen();
            }
            else if(usrinput == "2")
            {//if user want to open amazon prime
                PerformAmazonPrimeAppOpen();
            }
            else if(usrinput == "3")
            {
                loop = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }



    public void PerformNetflixAppOpen()
    {//if user open netflix then user can watch movies or leave
        Console.WriteLine("Netflix app is now open");
        string currentMovie = "";
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("1. Play The Manifesto");
            Console.WriteLine("2. Play Money Heist");
            Console.WriteLine("3. Exit app");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("The Manifesto started");
                currentMovie = "The Manifesto";
               //movie started
            }
            else if (input == "2")
            {
                Console.WriteLine("Money Heist started");
                currentMovie = "Money Heist";
                
            }
            else if (input == "3")
            {
                if (currentMovie != "")
                {
                    Console.WriteLine(currentMovie + " running paused");
                }
                Console.WriteLine("Exiting app...");
                loop = false;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }//if user enter other value than 1,2,3
        }
    }

    public void PerformAmazonPrimeAppOpen()
    {//if user want to open amazon prime then the user can watch movies
        Console.WriteLine("Amazon Prime app is now open");
        string currentMovie = "";
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("1. Play The Menu");
            Console.WriteLine("2. Play The Invitation");
            Console.WriteLine("3. Exit app");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("The Menu started");
                currentMovie = "The Menu";
                
            }
            else if (input == "2")
            {
                Console.WriteLine("The Invitation started");
                currentMovie = "The Invitation";
                
            }
            else if (input == "3")
            {
                if (currentMovie != "")
                {
                    Console.WriteLine(currentMovie + " running paused");
                }
                Console.WriteLine("Exiting app...");
                loop = false;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }




    public void CheckBitcoinPrices()
    {//checking bitcoin price if the user is connected to wifi
        if (Power)
        {
            if(Wireless == "WIFI"){
                PerformBitcoinAction();
            }
            else{
                Console.WriteLine("Please Connect to Wifi first");
            }
            
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }
    
    public void PerformBitcoinAction()
    {
        using (WebClient client = new WebClient())
        {
            try
            {//used coinbase free api to use the prices 
                string json = client.DownloadString("https://api.coinbase.com/v2/exchange-rates?currency=BTC");
                dynamic prices = JsonConvert.DeserializeObject<dynamic>(json);
                Console.WriteLine("Bitcoin rate: $" + prices.data.rates.USD);
            }
            catch (WebException e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

    }

    public void DisconnectFromBluetooth()
    {
        if (Power)
        {//if user want to disconnect bluetooth
            if(Connectivity=="Bluetooth"){
                Connectivity = "";
                Console.WriteLine("TV is now disconnected from Bluetooth.");
            }
            else{
                Console.WriteLine("TV is not connected to Bluetooth");//if tv is not connected to bluetooth
            }

        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }

    public void DisconnectFromWifi()
    {
        if (Power)
        {//disconnecting tv from wifi if user want to discconect wifi
            if(Wireless=="WIFI"){
                Wireless = "";
                Console.WriteLine("TV is now disconnected from WiFi.");
            }
            else{
                Console.WriteLine("TV is not connected to WiFi");//if tv is not connected to wifi
            }
        }
        else
        {
            Console.WriteLine("TV is off. Please turn it on first.");
        }
    }
    
    public void SelectLanguage(){//changing the language of tv
        Console.WriteLine("Select Language: ");
        Console.WriteLine("1. English");//three options of language default is englssh
        Console.WriteLine("2. Hindi");
        Console.WriteLine("3. Punjabi");
        string languageIndex = Console.ReadLine();
        if (languageIndex == "1")
        {
            CurrentLanguage = "english";
            Console.WriteLine("language changed to " + CurrentLanguage);
        }
        else if (languageIndex == "2")
        {
            CurrentLanguage = "hindi";
            Console.WriteLine("language changed to " + CurrentLanguage);
        }
        else if (languageIndex == "3")
        {
            CurrentLanguage = "punjabi";
            Console.WriteLine("language changed to " + CurrentLanguage);
        }
        else
        {
            Console.WriteLine("Please enter value 1,2,3");
        }
    }


    




}