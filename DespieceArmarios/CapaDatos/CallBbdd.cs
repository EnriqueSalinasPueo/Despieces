using Dapper;
using Dapper.Contrib.Extensions;
using DespieceArmarios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespieceArmarios.ClasesBd
{
    public static class CallBbdd

    {
        public static bool SaveDatos(Armario armario, List<Pieza> piezas, string cliente, string obra, List<ArmarioPiezas> armariosPiezasLista)
        {
            bool existe = false;
            Cliente recuperarCliente = null;
            Obra recuperaObra = null;
            Armario recuperarArmario = null;
                
            using (var conn = Bd.GetConnection())
            {
                recuperarCliente = conn.QuerySingle<Cliente>("select * from cliente where nombre = '" + cliente + "' ");

                recuperaObra = conn.QuerySingle<Obra>("select * from obra where nombre = '" + obra + "' and id_cliente = " + recuperarCliente.id_cliente);

                var resultado = conn.Query<Armario>("select * from armario where escalera = '" + armario.escalera + "' and piso = '" + armario.piso + "' and habitacion = '" + armario.habitacion + "' and id_obra = '" + recuperaObra.id_obra + "'");

                if (resultado.Count() == 0)
                {
                    armario.id_obra = recuperaObra.id_obra;
                    conn.Insert(armario);
                    //MessageBox.Show("Armario añadido");
                }
                else
                {
                    armariosPiezasLista.RemoveAt(armariosPiezasLista.Count - 1);
                    MessageBox.Show("Ya existe este armario para esta obra, por favor cambia su nombre de Habiatción.");
                    existe = true;
                    return false;
                }
            }
            if (!existe)
            {
                using (var conn = Bd.GetConnection())
                {
                    recuperarArmario = conn.QuerySingle<Armario>("select * from armario where escalera = '" + armario.escalera + "' and piso = '" + armario.piso + "' and habitacion = '" + armario.habitacion + "' and id_obra = '" + recuperaObra.id_obra + "'");
                    foreach (Pieza pi in piezas)
                    {
                        pi.id_armario = recuperarArmario.id_armario;
                        conn.Insert(pi);
                    }
                }
                return true;
                //MessageBox.Show("Piezas añadidas");
            }
            return false;
        }
        public static DefinirHolgurasGruesos GetHolgurasGruesos()
        {
            DefinirHolgurasGruesos holguraGrueso = new DefinirHolgurasGruesos();
            using (var conn = Bd.GetConnection())
            {
                holguraGrueso = conn.Query<DefinirHolgurasGruesos>("SELECT * FROM holguras_gruesos where id_holgurasGruesos = 1").First<DefinirHolgurasGruesos>();
            }
            return holguraGrueso;
        }
        public static Guia GetGuia()
        {
            Guia guia = new Guia();
            bool dat = false;
            using (var conn = Bd.GetConnection())
            {
                var resultado = conn.Query<Guia>("SELECT * FROM guia where id_guia = 1");
                if (resultado.Count() == 0)
                {
                    dat = false;
                    return null;
                }
                else
                {
                    dat = true;
                }
            }
            if (dat)
            {
                using (var conn = Bd.GetConnection())
                {
                    guia = conn.Query<Guia>("SELECT * FROM guia where id_guia = 1").First<Guia>();
                }
            }
            return guia;
        }
        public static List<Armario> GetListaArmarios(string obra, string nombreCliente)
        {
            List<Armario> listaArmarios;
            using (var conn = Bd.GetConnection())
            {
                Cliente recuperarCliente = conn.QuerySingle<Cliente>("select * from cliente where nombre = '" + nombreCliente + "' ");

                Obra recuperaObra = conn.QuerySingle<Obra>("select * from obra where nombre = '" + obra + "' and id_cliente = " + recuperarCliente.id_cliente);

                listaArmarios = conn.Query<Armario>("select * from armario where id_obra = " + recuperaObra.id_obra).ToList();
            }
            return listaArmarios;
        }
        public static List<Pieza> GetListaPiezas(Armario armario)
        {
            List<Pieza> listaPiezas = new List<Pieza>() ;
            using (var conn = Bd.GetConnection())
            {
                listaPiezas = conn.Query<Pieza>("select * from pieza where id_armario = " + armario.id_armario).ToList();
            }
            return listaPiezas;
        }
        public static bool DeleteArmario(Armario armario)
        {
            bool borrado = false;
            using (var conn = Bd.GetConnection())
            {
                Armario apoyo = conn.QueryFirst<Armario>("select * from armario where escalera= '" + armario.escalera + "' and piso = '" + armario.piso + "' and habitacion='" + armario.habitacion + "'");
                borrado = conn.Delete(apoyo);
                // MessageBox.Show(esBorrado.ToString());
            }

            return borrado;
        }
        public static void SaveClienteObra(string nombreCliente, string nombreObra)
        {
            using (var conn = Bd.GetConnection())
            {
                var resultado = conn.Query("select nombre from cliente where nombre = '" + nombreCliente.ToLower() + "' ");
                if (resultado.Count() == 0)
                {
                    Cliente cliente = new Cliente();
                    cliente.nombre = nombreCliente.ToLower();
                    conn.Insert(cliente);
                }
            }

            using (var conn = Bd.GetConnection())
            {
                int idCliente = conn.QuerySingle<int>("select id_cliente from cliente where nombre = '" + nombreCliente.ToLower() + "' ");

                var resultado = conn.Query("select nombre from obra where nombre = '" + nombreObra.ToLower() + "' and id_cliente = " + idCliente + "");
                if (resultado.Count() == 0)
                {
                    Obra obra = new Obra();
                    obra.nombre = nombreObra.ToLower();
                    obra.id_cliente = idCliente;
                    conn.Insert(obra);
                }
            }
        }
    }
}
