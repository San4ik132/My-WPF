using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;


namespace Pract_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_add_Click(object sender, RoutedEventArgs e)
        {                    
            if ( ID_()==true && Surname() == true && Name_() == true && Middl_name() == true  && Passport() == true && Telehpon() == true && Email() == true)
            {
                MessageBox.Show("Всё коректно, ваши данные добавлены!");
                File.AppendAllText("C:/Users/Pc/Desktop/employee.txt", 
                    $"{textID.Text.Trim()} " +                                                                       
                    $"{textSurname.Text.Trim()} " +                                                                       
                    $"{textName.Text.Trim()} " +                                                                       
                    $"{textMiddle_name.Text.Trim()} " +                                                                       
                    $"{textPassport.Text.Trim()} " +                                                                       
                    $"{textTelephone.Text.Trim()} " +                                                                       
                    $"{textEmail.Text.Trim()}\n");                
                textID.Clear();
                textSurname.Clear();
                textName.Clear();
                textMiddle_name.Clear();
                textPassport.Clear();
                textTelephone.Clear();
                textEmail.Clear();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так, пожалуйста попробуйте снова ");
            }
        }
        public bool ID_()
        {
            string id = textID.Text.Trim();
            string[] file = new string[] { };
            bool flag = true;
            file = File.ReadAllLines("C:/Users/Pc/Desktop/employee.txt");            
            foreach (string line in file)
            if (line.Split()[0] == id)
            {                 
                flag = false;
            }                                            
            if ( id.Length == 0 || flag == false || Regex.IsMatch(id, "[A-Za-z]+") || Regex.IsMatch(id, "[А-Яа-я]+"))
            {
                textID.ToolTip = "Такой идентификатор уже присутствует или поле пустое";
                textID.Background = Brushes.IndianRed;                                      
                return false;
            }
            else
            {
                textID.ToolTip = "";
                textID.Background = Brushes.Transparent;                                   
                return true;
            }         
        }
        public bool Telehpon()
        {

            string Telephone = textTelephone.Text.Trim();
            if (((Telephone.Length != 12 || Telephone[0] != '+' || Telephone[1] != '7' || Regex.IsMatch(Telephone, "[^0-9.^+]")) && 
                (Telephone.Length != 11 || Telephone[0] != '8')) || Regex.IsMatch(Telephone, "[A-Za-z]+") || Regex.IsMatch(Telephone, "[А-Яа-я]+"))
            {
                textTelephone.ToolTip = "Это поле введено не коректно";
                textTelephone.Background = Brushes.IndianRed;
                return false;
            }
            else
            {
                textTelephone.ToolTip = "";
                textTelephone.Background = Brushes.Transparent;
                return true;
            }
        }        
        public bool Email()
        {
            string Email = textEmail.Text.Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$");
            Match match = regex.Match(Email);
            if (!match.Success || Regex.IsMatch(Email, "[а-я]") || Regex.IsMatch(Email, "[А-Я]"))
            {
                textEmail.ToolTip = "Почта введе не верно";
                textEmail.Background = Brushes.IndianRed;
                return false;
            }
            else
            {
                textEmail.ToolTip = "";
                textEmail.Background = Brushes.Transparent;
                return true;
            }

        }
        public bool Passport()
        {
            string Passport = textPassport.Text.Trim();
            if (Regex.IsMatch(Passport, "[^0-9.]+") || Passport.Length != 10 || Regex.IsMatch(Passport, "[A-Za-z]+"))
            {
                textPassport.ToolTip = "Паспорт введён не верно";
                textPassport.Background = Brushes.IndianRed;
                return false;
            }
            else
            {
                textPassport.ToolTip = "";
                textPassport.Background = Brushes.Transparent;
                return true;
            }
        }
        public bool Name_()
        {
            string Name = textName.Text.Trim();
            if (Regex.IsMatch(Name, "[a-z]") || Regex.IsMatch(Name, "[A-Z]") || Name.Length == 0 || !Regex.IsMatch(Name, "[А-Я]+([а-я]+)?"))
            {
                textName.ToolTip = "Имя должно быть кирилицей и начинаться с большой буквы";
                textName.Background = Brushes.IndianRed;
                return false;
            }
            else
            {
                textName.ToolTip = "";
                textName.Background = Brushes.Transparent;
                return true;
            }

        }
        public bool Surname()
        {
            string Surname = textSurname.Text.Trim();
            if (Regex.IsMatch(Surname, "[a-z]") || Regex.IsMatch(Surname, "[A-Z]") || Surname.Length == 0 || !Regex.IsMatch(Surname, "[А-Я]+([а-я]+)?"))
            {
                textSurname.ToolTip = "Фамилия должно быть кирилицей и начинаться с большой буквы";
                textSurname.Background = Brushes.IndianRed;
                return false;
            }
            else
            {
                textSurname.ToolTip = "";
                textSurname.Background = Brushes.Transparent;
                return true;
            }
        }
        public bool Middl_name()
        {

            string Middl_name = textMiddle_name.Text.Trim();
            if (Regex.IsMatch(Middl_name, "[a-z]") || Regex.IsMatch(Middl_name, "[A-Z]") || Middl_name.Length == 0 || !Regex.IsMatch(Middl_name, "[А-Я]+([а-я]+)?"))
            {
                textMiddle_name.ToolTip = "Отчество должно быть кирилицей и начинаться с большой буквы";
                textMiddle_name.Background = Brushes.IndianRed;
                return false;
            }
            else
            {
                textMiddle_name.ToolTip = "";
                textMiddle_name.Background = Brushes.Transparent;
                return true;
            }

        }
    }
}
