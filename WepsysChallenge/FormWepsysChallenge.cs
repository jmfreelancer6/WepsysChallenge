using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WepsysChallenge.Api;
using WepsysChallenge.Models;

namespace WepsysChallenge
{
    public partial class FormWepsysChallenge : Form
    {
        private ApiBase api = new ApiPerson();
        private ValidateHttpResponse validate = new ValidateHttpResponse();
        public FormWepsysChallenge()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            flowlayoutpanelerror.Controls.Clear();
            Person _person = new Person();
            _person.Nombre = txtNombre.Text;
            _person.Apellido = txtApellido.Text;
            _person.Email = txtEmail.Text;
            HttpResponseMessage respon = api.requestApiPost(_person);
            (Error messageError, Response ok) = validate.ValidateResponse(respon);
            showMessage(messageError, ok);
            fillDGVPerson();
        }

        private void showMessage(Error messageError, Response ok)
        {
            if (messageError != null)
            {
                foreach (string item in messageError.errores)
                {
                    Label lbl = new Label();
                    lbl.Text = item;
                    lbl.AutoSize = true;
                    flowlayoutpanelerror.Controls.Add(lbl);
                }
            }
            else if (ok != null)
            {
                lblMessage.Text = ok.message;
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void FormWepsysChallenge_Load(object sender, EventArgs e)
        {
            fillDGVPerson();
        }
        private void fillDGVPerson()
        {
            dgvPerson.DataSource = JsonConvert.DeserializeObject<IEnumerable<Person>>(api.requestApiGet());
        }

        private void dgvPerson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Response resp = JsonConvert.DeserializeObject<Response>(api.requestApiDelete(int.Parse(senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString())));
                    lblMessage.Text = resp.message;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    fillDGVPerson();
                }
            }
        }
    }
}
