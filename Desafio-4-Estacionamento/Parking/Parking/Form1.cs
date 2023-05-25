using Parking.Entities;
using Parking.Interfaces;

namespace Parking
{
    public partial class FormInitial : Form
    {
        private readonly IParkingService _parkingService;

        public FormInitial(IParkingService parkingService)
        {
            _parkingService = parkingService;
            InitializeComponent();
            timer1.Start();
            richTextBoxEntry.Text = _parkingService.GetAllParkedVehicles();
            richTextBoxExits.Text = _parkingService.GetAllExitsVeicles();
            //textBoxDateTime = DateTime.Now.ToString();
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            var plate = textBoxPlate.Text;
            var parkedVehicle = new ParkedVehicle(plate);
            var response = _parkingService.VehicleEntrance(parkedVehicle);

            MessageBox.Show(response.StatusMessage);

            richTextBoxEntry.Text = _parkingService.GetAllParkedVehicles();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var plate = textBoxPlate.Text;
            var parkedVehicle = new ParkedVehicle(plate);
            var response = _parkingService.VehicleExit(parkedVehicle);

            MessageBox.Show(response.StatusMessage);

            richTextBoxEntry.Text = _parkingService.GetAllParkedVehicles();
            richTextBoxExits.Text = _parkingService.GetAllExitsVeicles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHours.Text = DateTime.Now.ToString();
        }

    }
}