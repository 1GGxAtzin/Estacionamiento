using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACTIVIDAD4
{
    public partial class Form1 : Form
    {

        private List<elementos> lista;
        Thread hilo;
        int ident = 1;
        int i;
        int j;
        int coins = 0;
        int money;

        List<int> array1 = new List<int>();
        List<int> array2 = new List<int>();

        public Form1()
        {
            InitializeComponent();
            txtcoins.Text = (coins.ToString());
            txtc.Enabled = false;
            hilo = new Thread(tiempo);
            CheckForIllegalCrossThreadCalls = false;

            //COLUMNAS
            string inicial = "ID\t\tHORA DE ENTRADA\t\tHORA DE SALIDA\t\tCOSTO";
            listbox.DataSource = null;
            listbox.Items.Add(inicial);
            listbox.Refresh(); 
            //LISTA
            lista = new List<elementos>();
            hilo.Start();
          
        }
        
        void tiempo()
        { 
            
            int horachida = DateTime.Now.Hour;
            int minutoschidos = DateTime.Now.Minute;
            i = horachida;
            label2.Text = (i.ToString());

            for (j = minutoschidos; j <= 59; j++)
            {
                label3.Text = (j.ToString());
                if (j == 59)
                {
                    Thread.Sleep(1000);
                    j = 0;
                    minutoschidos = 0;
                    label2.Text = (i.ToString());
                    label3.Text = (j.ToString());
                    if (i != 23)
                    {
                        i++;
                        label2.Text = (i.ToString());
                    }
                    if (i == 23)
                    {
                        i = 0;
                        horachida = 0;
                        label2.Text = (i.ToString());
                        label2.Refresh();
                    }
                }
                Thread.Sleep(1000);
                label3.Refresh();

            }
        }

        public void agregar(string hora,int dato, int costo, string horas)
        {
            elementos p = new elementos(hora, dato, costo, horas);
            lista.Add(p);     
            string cadena = p.dato+ "\t\t           " + p.hora + "\t\t\t             " +p.horas+ "\t\t\t     " +p.costo;
            listbox.DataSource = null;
           
        

            listbox.Items.Add(cadena);
            listbox.Refresh();

        }
       
        private void comenzar_Click(object sender, EventArgs e)
        {
            comenzar.Enabled = false;
            comenzar.Refresh();
            int cuenta = 3;
            id.Text = ("ID: " + ident.ToString());
            id.Refresh();
            listbox.Text = ("ID : " + ident.ToString()+ "\n");
            listbox.Refresh();
            box1.Text = ("Ticket Generado...");
            box1.Refresh();
            array1.Add(i);
            array2.Add(j);
            String numVal = (i+": "+ j);
            int a = 0;
            string b = "0";
            agregar(numVal, ident, a, b);

            

            //listbox.DataSource =;
            listbox.Refresh();
            text2.Text = (cuenta.ToString());
            while (cuenta >= 1){
                text2.Text = ("Desaparecera en: "+ cuenta.ToString());
                cuenta--;
                text2.Refresh();
                Thread.Sleep(1000);
            }
            text2.Clear();
            box1.Clear();
            id.Text = ("");
            ident++;
            comenzar.Enabled = true;
           
        }
        void cambio(int money)
        {
            List<int> Cambio = new List<int>();
            if (txtcoins.Text != "" && txtcoins.Text != "0")
            {
                MessageBox.Show("Se cobraran:  "+ txtc.Text + " pesos, de: "+txtcoins.Text);
                
                    List<int> cuantasson = new List<int>();

                    if (check20.Checked)
                    {
                        Cambio.Add(20);
                        cuantasson.Add(0);
                    }
                    if (check10.Checked)
                    {
                        Cambio.Add(10);
                        cuantasson.Add(0);
                    }
                    if (check5.Checked)
                    {
                        Cambio.Add(5);
                        cuantasson.Add(0);
                    }
                    if (check2.Checked)
                    {
                        Cambio.Add(2);
                        cuantasson.Add(0);
                    }
                    if (check1.Checked)
                    {
                        Cambio.Add(1);
                        cuantasson.Add(0);
                    }
                    int total = 0;
                    List<int> Respuesta = new List<int>();
                    int contador = 0;
                    int x = Cambio[contador];
                    while (total < money)
                    {
                        x = Cambio[contador];
                        if ((total + x) <= money)
                        {
                            Respuesta.Add(x);
                            total = total + x;
                            cuantasson[contador]++;
                        }
                        else
                        {
                            x = Cambio[contador++];
                        }
                    }

                    txtcoins.Clear();
                    coins = 0;
                    string str = Convert.ToString(coins);
                    txtcoins.SelectedText = str;
                    string variable = "SU CAMBIO ES: \n";
                    for (int i = 0; i < Cambio.Count(); ++i)
                    {
                        if (cuantasson[i] > 0)
                        {
                            variable += "$ " + Cambio[i] + " :  " + cuantasson[i] + "\n";
                        }


                    }
                    MessageBox.Show(variable);



                
            }
            else
            {
                MessageBox.Show("No tienes COINS");
            }
        }
        void costogg(int z)
        {
            int costof;
            costof = i - array1[z];
            if (costof == 0)
            {
                int costochido = j - array2[z];
                if (costochido <= 15)
                {
                    lista[z].costo = 5;
                }
                else
                {
                    lista[z].costo = 10;
                }
            }
            if (costof == 1)
            {
                if (j < array2[z] && array2[z] >= 45 && array2[z] -j <=15)
                {
                    lista[z].costo = 5;
                }
                else if (j < array2[z] && array2[z] >= 45 && array2[z] - j >= 15)
                {
                    if((60 -array2[z]) + j <= 15)
                    {
                        lista[z].costo = 5;

                    }
                    else
                    lista[z].costo = 10;
                }
                else if (j > array2[z])
                {
                    lista[z].costo = (10 * costof) + 10;
                }
                else if (j < array2[z] && array2[z]<45)
                {

                    lista[z].costo = (10 * costof);
                }
            }
            if (costof > 1)
            {
                
                if (j > array2[z])
                {
                    lista[z].costo = (10 * costof) + 10;
                }
                else
                {
                    lista[z].costo = (10 * costof);
                }
            }

            txtc.Text = (lista[z].costo.ToString());
        }

            private void button1_Click(object sender, EventArgs e)
        {
            
            bool chido = false;
            if (valor.Text != "")
            {

                for(int z=0; z< lista.Count(); z++)
                {
                    if (valor.Text == lista[z].dato.ToString())
                    {

                        if (lista[z].costo == 0)
                        {
                            costogg(z);

                            button1.Enabled = false;
                            String val = (i + ": " + j);
                            lista[z].horas = val;
                            listbox.DataSource = null;

                            money = lista[z].costo;
                            btn20.Enabled = true;
                            btn10.Enabled = true;
                            btn5.Enabled = true;
                            btn2.Enabled = true;
                            btn1.Enabled = true;



                            /*
  String val = (i + ": " + j);
                                lista[z].horas = val;
                                listbox.DataSource = null;

                                int money = coins - lista[z].costo;












    */
                            string cadena = lista[z].dato + "\t\t           " + lista[z].hora + "\t\t\t             " + lista[z].horas + "\t\t     " + lista[z].costo;

                            listbox.Items[z + 1] = cadena;

                            listbox.Refresh();
                            valor.Text = "";
                            chido = true;
                        }
                        else
                        {
                            if (lista[z].costo != 0)
                            {
                                MessageBox.Show("ID YA PAGADO");
                                chido = true;
                                valor.Text = "";
                            }
                        }

                    }
                    
                        
                    
                    
                    
                }
                if (chido == false)
                {
                    MessageBox.Show("ID NO ENCONTRADO");
                    valor.Text = "";
                }
            }
            else
                
            
                MessageBox.Show("INGRESE UN ID");
           
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            txtcoins.Clear();
            coins += 20;
            string str = Convert.ToString(coins);
            txtcoins.SelectedText = str;
            if(coins>= money)
            {
                int dinero = coins- money;
                cambio(dinero);
                txtc.Text = "";
                button1.Enabled = true;
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtcoins.Clear();
            coins += 10;
            string str = Convert.ToString(coins);
            txtcoins.SelectedText = str;
            if (coins >= money)
            {
                int dinero = coins - money;
                cambio(dinero);
                txtc.Text = "";
                button1.Enabled = true;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtcoins.Clear();
            coins += 5;
            string str = Convert.ToString(coins);
            txtcoins.SelectedText = str;
            if (coins >= money)
            {
                int dinero = coins - money;
                cambio(dinero);
                txtc.Text = "";
                button1.Enabled = true;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtcoins.Clear();
            coins += 2;
            string str = Convert.ToString(coins);
            txtcoins.SelectedText = str;
            if (coins >= money)
            {
                int dinero = coins - money;
                cambio(dinero);
                txtc.Text = "";
                button1.Enabled = true;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtcoins.Clear();
            coins += 1;
            string str = Convert.ToString(coins);
            txtcoins.SelectedText = str;
            if (coins >= money)
            {
                int dinero = coins - money;
                cambio(dinero);
                txtc.Text = "";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
