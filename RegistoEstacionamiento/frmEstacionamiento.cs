namespace RegistoEstacionamiento
{
    public partial class frmEstacionamiento : Form
    {
        string dia;
        public frmEstacionamiento()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MOSTRANDO LA FECHA ACTUAL
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //DETERMINAR EL DIA 

            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double costo = 0;
            switch (dia) {

                case "domingo" : costo = 2; break;
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                    costo = 4; break;

                case "viernes":
                case "sabado":
                    costo = 7; break;
            }

            lblCosto.Text = costo.ToString("0.00");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //CALCULANDO LOS GASTOS DEL FORMULARIO 
            
            string placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime horaInicio = DateTime.Parse(txtHoraInicio.Text);
            DateTime horaFin = DateTime.Parse(txtHoraFin.Text);

            //CALCULAR LA HORA 

            TimeSpan hora = horaFin - horaInicio;

            //CALCULAR EL IMPORTE 

            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horaInicio.ToString("t"));
            fila.SubItems.Add(horaFin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            lvRegistro.Items.Add(fila);
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtHoraFin.Clear();
            txtHoraInicio.Clear();
            txtPlaca.Clear();
            txtPlaca.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro de salir?",
            "Registro de Multas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}