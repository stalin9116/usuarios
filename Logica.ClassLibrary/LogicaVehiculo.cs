using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaVehiculo
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Vehiculo> getVehiculos()
        {
            try
            {
                var vehiculo = dc.Vehiculo.Where(data => data.veh_status == 'A');

                return vehiculo.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Vehiculos " + ex.Message);
            }
        }

        public static Vehiculo getVehiculoXId(int id)
        {
            try
            {
                var vehiculo = dc.Vehiculo.FirstOrDefault(data => data.veh_status == 'A'
                                                       && data.veh_id.Equals(id));

                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Vehiculos " + ex.Message);
            }
        }

        public static Vehiculo getVehiculoXPlaca(string placa)
        {
            try
            {
                var vehiculo = dc.Vehiculo.FirstOrDefault(data => data.veh_status == 'A'
                                                       && data.veh_placaactual.Equals(placa));

                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Vehiculos " + ex.Message);
            }
        }


        public static bool deleteVehiculo(Vehiculo vehiculo)
        {
            try
            {
                vehiculo.veh_status = 'I';
                dc.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool saveVehiculo(Vehiculo dataVehiculo)
        {
            try
            {
                bool result = false;
                dataVehiculo.veh_add = DateTime.Now;
                dataVehiculo.veh_status = 'A';

                var vehiculo= getVehiculoXPlaca(dataVehiculo.veh_placaactual);

                if (vehiculo != null)
                {
                    throw new ArgumentException("Vehiculo ya existe");
                }

                dc.Vehiculo.InsertOnSubmit(dataVehiculo);
                //Commit a la base
                dc.SubmitChanges();


                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al guardar Vehiculo " + ex.Message);
            }
        }

    }
}
