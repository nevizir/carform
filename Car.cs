namespace carform
{
    public partial class CarForm : Form
    {
        List<Car> cars = new List<Car>();
        List<string> brands = new List<string>();
        List<string> colors = new List<string>();

        public CarForm()
        {
            InitializeComponent();
            LoadBrands();
            UpdateBrandsListBox();
            Load—olors();
            Update—olorsListBox();
        }

        private void LoadBrands()
        {
            
            brands.Add("Volvo");
            brands.Add("Volkswagen");
            brands.Add("Toyota");
            brands.Add("Mercedes-Benz");
            brands.Add("Audi");
            brands.Add("BMW");

            UpdateBrandsListBox();
        }
        private void UpdateBrandsListBox()
        {
            BrabdComboBox.DataSource = null;
            BrabdComboBox.DataSource = brands;
        }

        private void Load—olors()
        {

            colors.Add("Black");
            colors.Add("Red");
            colors.Add("Orange");
            colors.Add("White");
            colors.Add("Blue");
            colors.Add("Grey");

            Update—olorsListBox();
        }
        private void Update—olorsListBox()
        {
            ColorComboBox.DataSource = null;
            ColorComboBox.DataSource = colors;
        }

        private void UpdateCarsListBox()
        {
            CarComboBox.DataSource = null;
            CarComboBox.DataSource = cars;
        }

        private bool CheckInputs()
        {
            bool inputs = false;
            if (string.IsNullOrWhiteSpace(BrabdComboBox.Text) ||
                string.IsNullOrWhiteSpace(ModelTextBox.Text) ||
                string.IsNullOrWhiteSpace(ColorComboBox.Text) ||
                string.IsNullOrWhiteSpace(NumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(VinNumberTextBox.Text))
                inputs = false;
            else
                inputs = true;

            return inputs;
        }

   

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (CheckInputs() == false)
            {
                MessageBox.Show("Enter valid data!");
                return;
            }

            cars.Add
            (
                new Car
                {
                    Brand = BrabdComboBox.Text,
                    Model = ModelTextBox.Text,
                    Color = ColorComboBox.Text,
                    Year = (int)YearUpDown.Value,
                    Number = NumberTextBox.Text,
                    VinNumber = VinNumberTextBox.Text
                }
            );
            UpdateCarsListBox();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var car = CarComboBox.SelectedItem as Car;

            cars.Remove(car);
            UpdateCarsListBox();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            if (CarComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select car to show!");
                return;
            }

            Car car = CarComboBox.SelectedItem as Car;

            MessageBox.Show(
                $"{car.Brand} {car.Model}\n" +
                $"{car.Color}\n" +
                $"{car.Year}\n" +
                $"{car.Number}\n" +
                $"{car.VinNumber}", "Car info", MessageBoxButtons.OK, MessageBoxIcon.Information
            );
        }
    }




    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        public string VinNumber { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} {Year}";
        }
    }



}