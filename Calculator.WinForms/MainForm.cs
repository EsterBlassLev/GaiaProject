using Calculator.Core.Models;
using System.Net.Http.Json;

namespace Calculator.WinForms
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _client;
        private List<string> _operations;

        public MainForm()
        {
            InitializeComponent();
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7291/")
            };
            LoadOperationsAsync();
        }

        private async void LoadOperationsAsync()
        {
            try
            {
                _operations = await _client.GetFromJsonAsync<List<string>>("api/calculator/operations");
                cboOperation.DataSource = _operations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading operations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                var request = new CalculationRequest
                {
                    FieldA = txtFieldA.Text,
                    FieldB = txtFieldB.Text,
                    OperationType = cboOperation.SelectedItem.ToString()
                };

                var response = await _client.PostAsJsonAsync("api/calculator/calculate", request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<CalculationResult>();
                    lblResult.Text = $"Result: {result.Result}";

                    await LoadHistoryAsync(request.OperationType);
                    await LoadMonthlyCountAsync(request.OperationType);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Calculation failed: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadHistoryAsync(string operationType)
        {
            try
            {
                var history = await _client.GetFromJsonAsync<List<CalculationResult>>($"api/calculator/history/{operationType}");
                lstHistory.Items.Clear();
                foreach (var item in history)
                {
                    lstHistory.Items.Add($"{item.FieldA} {item.Operation} {item.FieldB} = {item.Result} ({item.CalculationTime})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadMonthlyCountAsync(string operationType)
        {
            try
            {
                var count = await _client.GetFromJsonAsync<int>($"api/calculator/monthly-count/{operationType}");
                lblMonthlyCount.Text = $"Operations this month: {count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (txtFieldA.Text==null)
            {
                MessageBox.Show("Please enter a valid number for Field A", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtFieldB.Text==null)
            {
                MessageBox.Show("Please enter a valid number for Field B", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboOperation.SelectedItem == null)
            {
                MessageBox.Show("Please select an operation", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}