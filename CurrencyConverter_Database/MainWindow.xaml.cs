/*
 * Name: Yuhao Peng
 * Date: 2022-07-25
 * Last Update On: 2022-07-27
 * Title of Work: Currency Converter Using Database
 * Discription: An advanced Currency Converter that 
 *              allows customizing the currency exchange rate 
 *              by using 'currency master' and 
 *              performing the currency conversion.
 * */


using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace CurrencyConverter_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create sql connection object
        private SqlConnection sqlConnection = new SqlConnection();

        //create sql command object
        private SqlCommand sqlCommand = new SqlCommand();

        //create sql data adapter object
        private SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        //create a variable that holds currency id for update in Currency Master tab
        private int currencyId = 0;

        //create variables for holding currency amount from table
        private decimal fromAmount, toAmount;
        
        public MainWindow()
        {
            InitializeComponent();
            //make sure UI controls are reset to default when page loads
            ResetContent();
            //load items to the combo boxes
            BindCurrency();
            //load database record to the data grid on Currency Master data grid
            LoadData();
        }

        /// <summary>
        /// Establish a connection with SQL server database and open the database connection.
        /// </summary>
        public void OpenConnection()
        {
            //declare sql server database connection string
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //initialize sql connection object
            sqlConnection = new SqlConnection(connection);
            //open database connection
            sqlConnection.Open();
        }

        /// <summary>
        /// Retrive data from Currency_Master table in CurrencyConverterDB and display data to combo boxes on UI.
        /// </summary>
        private void BindCurrency()
        {
            //connect to database
            OpenConnection();
            //create a datatable object for holding tabular data from sql server
            DataTable datatable = new DataTable();
            //create sql query to get relevant data from Currency_Master table
            sqlCommand = new SqlCommand("SELECT Id, Amount, CurrencyName FROM Currency_Master", sqlConnection);
            //specify type of command for writing sql query
            sqlCommand.CommandType = CommandType.Text;
            //initialize sql data adapter
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //retrive table data and save them in datatable
            sqlDataAdapter.Fill(datatable);

            //create a datarow object to add new rows to datatable
            DataRow newRow = datatable.NewRow();
            //assigning values to table columns
            newRow["Id"] = 0;
            newRow["CurrencyName"] = "--SELECT--";
            //inset new rows to datatable with values at a specific position(0)
            datatable.Rows.InsertAt(newRow, 0);

            if (datatable != null && datatable.Rows.Count > 0)        //validate if data is retrieved successfully from server
            {
                //binding datatable data to combo boxes on the UI
                cboFromCurrency.ItemsSource = datatable.DefaultView;
                cboToCurrency.ItemsSource = datatable.DefaultView;
            }
            //close sql server connection
            sqlConnection.Close();
            
            //set the combo box display items and the actual values behind
            cboFromCurrency.DisplayMemberPath = "CurrencyName";
            cboFromCurrency.SelectedValuePath = "Amount";
            cboToCurrency.DisplayMemberPath = "CurrencyName";
            cboToCurrency.SelectedValuePath = "Amount";

            //set combo boxes default selected item
            cboFromCurrency.SelectedIndex = 0;
            cboToCurrency.SelectedIndex = 0;
        }

        /// <summary>
        /// Binding database records in datagrid view on UI.
        /// </summary>
        private void LoadData()
        {
            //open database connection
            OpenConnection();
            //declare a new datatable object
            DataTable datatable = new DataTable();
            //sql query for getting data from Currency_Master table.
            sqlCommand = new SqlCommand("SELECT * FROM Currency_Master", sqlConnection);
            //specify command type(text, store procedure, table direct...)
            sqlCommand.CommandType = CommandType.Text;
            //initialize sql data adatper
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //retrieve table data and save them in datatable
            sqlDataAdapter.Fill(datatable);

            if (datatable != null && datatable.Rows.Count > 0)        //validate if data is retrieved successfully from server
            {
                //binding datatable data to data grid on the UI
                dgCurrency.ItemsSource = datatable.DefaultView;
            }
            else
            {
                //leave data grid empty if data is not retrieved from server
                dgCurrency.ItemsSource = null;
            }

            //close database connection
            sqlConnection.Close();
        }

        /// <summary>
        /// Reset all the controls input that user entered or selected. Display message dialog if error occurs.
        /// </summary>
        private void ResetContent()
        {
            try
            {
                //empty the amount textbox text
                txtCurrency.Text = string.Empty;

                //clear the currency label content
                lblCurrency.Content = string.Empty;

                //reset combo box select item to default
                if (cboFromCurrency.Items.Count > 0)
                    cboFromCurrency.SelectedValue = 0;
                if (cboToCurrency.Items.Count > 0)
                    cboToCurrency.SelectedValue = 0;

                //set focus on amount textbox
                txtCurrency.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Reset all the controls input that user entered. Display message dialog if error occurs.
        /// </summary>
        private void ResetContentMaster()
        {
            try
            {
                //empty the textboxes
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;

                //reset button content
                btnSave.Content = "Save";

                //reset the data grid
                LoadData();

                //set currency Id variable to 0
                currencyId = 0;

                //reload currency data from database
                BindCurrency();

                //set focus to amount textbox
                txtAmount.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            //declare a variable to store currency converted value
            decimal convertedResult;

            //display message if textbox is empty and combo box is not selected or at default selection
            if(txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please enter currency.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCurrency.Focus();
                return;
            }
            else if (cboFromCurrency.SelectedValue == null || cboFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please select currency from.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cboFromCurrency.Focus();
                return;
            }
            else if (cboToCurrency.SelectedValue == null || cboToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please select currency to.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cboToCurrency.Focus();
                return;
            }

            //check if from and to combobox has same value selected
            if(cboFromCurrency.Text == cboToCurrency.Text)
            {
                //the converted value is exactly the amount that user entered
                convertedResult = decimal.Parse(txtCurrency.Text);
                //display the result to the label
                lblCurrency.Content = $"{cboToCurrency.Text} {convertedResult.ToString("C2")}";
            }
            else
            {
                convertedResult = (decimal.Parse(cboFromCurrency.SelectedValue.ToString()) * decimal.Parse(txtCurrency.Text)) / decimal.Parse(cboToCurrency.SelectedValue.ToString());
                lblCurrency.Content = $"{cboToCurrency.Text} {convertedResult.ToString("C2")}";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ResetContent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Only allowing interger value to be entered in textbox.
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cboFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //check if fromCurrency combobox has item selected and it is not default selection
                if(cboFromCurrency.SelectedValue != null && int.Parse(cboFromCurrency.SelectedValue.ToString()) != 0 && cboFromCurrency.SelectedIndex != 0)
                {
                    //get the selected item value (Id)
                    int currencyFromId = int.Parse(cboFromCurrency.SelectedValue.ToString());

                    //open database connection and declare datatable
                    OpenConnection();
                    DataTable datatable = new DataTable();

                    //sql query for get currency amount from database using id
                    sqlCommand = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @Id", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;

                    //add parameter, make sure currency from id is not 0
                    if(currencyFromId != 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", currencyFromId);
                    }
                    //initialize sql data adapter, retrieve data from table
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(datatable);

                    if (datatable != null && datatable.Rows.Count > 0)    //check if data is retrieved successfully
                    {
                        //get the currency amount from datatable and store in variable
                        fromAmount = decimal.Parse(datatable.Rows[0]["Amount"].ToString());
                    }
                    
                    //close database connection
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cboToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //check if toCurrency combobox has item selected and it is not default selection
                if (cboToCurrency.SelectedValue != null && int.Parse(cboToCurrency.SelectedValue.ToString()) != 0 && cboToCurrency.SelectedIndex != 0)
                {
                    //get the selected item value (Id)
                    int currencyToId = int.Parse(cboToCurrency.SelectedValue.ToString());

                    //open database connection and declare datatable
                    OpenConnection();
                    DataTable datatable = new DataTable();

                    //sql query for get currency amount from database using id
                    sqlCommand = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @Id", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;

                    //add parameter, make sure currency to id is not 0
                    if (currencyToId != 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", currencyToId);
                    }
                    //initialize sql data adapter, retrieve data from table
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(datatable);

                    if (datatable != null && datatable.Rows.Count > 0)    //check if data is retrieved successfully
                    {
                        //get the currency amount from datatable and store in variable
                        toAmount = decimal.Parse(datatable.Rows[0]["Amount"].ToString());
                    }

                    //close database connection
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cboFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if user press tab or enter key on keyboard, cboFromCurrency_SelectionChanged event fire
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                cboFromCurrency_SelectionChanged(sender, null);
        }

        private void cboToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if user press tab or enter key on keyboard, cboToCurrency_SelectionChanged event fire
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                cboToCurrency_SelectionChanged(sender, null);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //validate textbox inputs
                if(txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter amount.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtAmount.Focus();
                    return;
                }
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter currency name.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCurrencyName.Focus();
                    return;
                }
                else
                {
                    //start update process if user click edit button
                    if (currencyId > 0)
                    {
                        //display confirmation message
                        if (MessageBox.Show("Are you sure you want to update this record?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //open database connection
                            OpenConnection();
                            //declare datatable object
                            DataTable datatable = new DataTable();
                            //sql query to update record 
                            sqlCommand = new SqlCommand("UPDATE Currency_Master SET Amount = @Amount, CurrencyName = @CurrencyName WHERE Id = @Id", sqlConnection);
                            //specify command type
                            sqlCommand.CommandType = CommandType.Text;
                            //add parameters
                            sqlCommand.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            sqlCommand.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text.ToUpper());
                            sqlCommand.Parameters.AddWithValue("@Id", currencyId);
                            //execute query
                            sqlCommand.ExecuteNonQuery();
                            //close database connection
                            sqlConnection.Close();
                            //display succeed  message
                            MessageBox.Show("Record updated successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        //start save process when user click on yes button after the confirmation message
                        if (MessageBox.Show("Are you sure you want to save this record?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //open database connection
                            OpenConnection();
                            //declare a new datatable
                            DataTable datatable = new DataTable();
                            //create sql query to add record to Currency_Master table
                            sqlCommand = new SqlCommand("INSERT INTO Currency_Master(Amount, CurrencyName) VALUES(@Amount, @CurrencyName)", sqlConnection);
                            //specify sql command type
                            sqlCommand.CommandType = CommandType.Text;
                            //add parameters
                            sqlCommand.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            sqlCommand.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text.ToUpper());
                            //execute sql query withour returning any data(update, insert, delete...)
                            sqlCommand.ExecuteNonQuery();
                            //close database connection
                            sqlConnection.Close();
                            //show message indicate save process succeed
                            MessageBox.Show("Record saved successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    //reload the table record to the grid on UI after save or update process completed
                    ResetContentMaster();
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResetContentMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                //create datagrid object
                DataGrid dataGrid = (DataGrid)sender;
                //create datarowview object
                DataRowView selectedRow = dataGrid.CurrentItem as DataRowView;

                //check if row selected is not null
                if (selectedRow != null)
                {
                    //check if there are items in the data grid
                    if (dgCurrency.Items.Count > 0)
                    {
                        if (dataGrid.SelectedCells.Count > 0)
                        {
                            //get selected row id value and store in currency id variable
                            currencyId = int.Parse(selectedRow["Id"].ToString());

                            //if user choose to edit record (datagrid template column display index is 0)
                            if (dataGrid.SelectedCells[0].Column.DisplayIndex == 0)
                            {
                                //display selected record information in textboxes
                                txtAmount.Text = selectedRow["Amount"].ToString();
                                txtCurrencyName.Text = selectedRow["CurrencyName"].ToString();

                                //change btnSve content to update
                                btnSave.Content = "Update";
                            }

                            //if user choose to delete record (datagrid template column display index is 1)
                            if (dataGrid.SelectedCells[0].Column.DisplayIndex == 1)
                            {
                                //show confirmation dialog
                                if (MessageBox.Show("Are you sure you want to delete this record?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    //open database connection
                                    OpenConnection();
                                    //declare datatable object
                                    DataTable datatable = new DataTable();
                                    //sql qurery for deleting record from table using id
                                    sqlCommand = new SqlCommand("DELETE FROM Currency_Master WHERE Id = @Id", sqlConnection);
                                    //specify command type
                                    sqlCommand.CommandType = CommandType.Text;
                                    //add parameter
                                    sqlCommand.Parameters.AddWithValue("@Id", currencyId);
                                    //execute qurey
                                    sqlCommand.ExecuteNonQuery();
                                    //close database connection
                                    sqlConnection.Close();
                                    //display message
                                    MessageBox.Show("Record delected successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    //refresh UI content
                                    ResetContentMaster();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
