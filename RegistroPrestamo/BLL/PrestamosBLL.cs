using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.DAL;
using RegistroPrestamo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPrestamo.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamo prestamo)
        {
            if (!Existe(prestamo.prestamoId))//si no existe insertamos
                return Insertar(prestamo);
            else
                return Modificar(prestamo);

        }

        private static bool Insertar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(prestamo);
                //le sumamos el balance a la persona
                contexto.Personas.Find(prestamo.personaId).balance += prestamo.balance;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            decimal BalanceAnterior = Buscar(prestamo.prestamoId).balance;
            int PersonaIdAnterior = Buscar(prestamo.prestamoId).personaId;
            Contexto contexto = new Contexto();

            try
            {
            
                if(PersonaIdAnterior!= prestamo.personaId)
                {
                    contexto.Personas.Find(PersonaIdAnterior).balance -= BalanceAnterior;
                    contexto.Personas.Find(prestamo.personaId).balance += prestamo.balance;
                }
                else
                {
                    contexto.Personas.Find(prestamo.personaId).balance -= BalanceAnterior;
                    contexto.Personas.Find(prestamo.personaId).balance += prestamo.balance;
                }
                
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var auxPrestamo = contexto.Prestamos.Find(id);
                if (auxPrestamo != null)
                {
                    contexto.Personas.Find(auxPrestamo.personaId).balance -= auxPrestamo.balance; //le resto el balance a la persona
                    contexto.Prestamos.Remove(auxPrestamo);//remueve la entidad
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Prestamo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamo prestamo;

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamo;

        }

        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> prestamo)
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Prestamos.Where(prestamo).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(p => p.prestamoId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }

        public static List<Prestamo> GetPrestamos()
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(p => true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
