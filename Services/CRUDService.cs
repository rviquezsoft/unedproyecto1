using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Proyecto1.Models;

namespace Proyecto1.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CRUDService<T> : ICRUDService<T> where T : new()
    {
        private readonly List<T> _entities;
        public CRUDService(List<T> entities)
        {
            _entities = entities;
        }
        public int CountAll()
        {
            return _entities.Count;
        }
        public List<T> Get()
        {
            try
            {
                return _entities;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public T GetById(string nid, int id)
        {
            try
            {
                if (_entities.Count < 1)
                {
                    return default(T);
                }
                T entity = new T();
                //obtener la propiedad que es el id 
                PropertyInfo property = entity.GetType().GetProperty(nid);

                //buscar el elemento en la lista
                T find = _entities
                                .Where(x => Convert.ToInt32(property.GetValue(x)) == id)
                                .FirstOrDefault();

                return find;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
                return default(T);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Add(T entity)
        {
            try
            {
                _entities.Add(entity);
                return "El elemento se agregó correctamente";

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="nid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update(T entity,string nid, int id)
        {
            try
            {
                if (_entities.Count < 1)
                {
                    return "El elemento no se encontró";
                }
                //obtener la propiedad que es el id 
                PropertyInfo property = entity.GetType().GetProperty(nid);

                //buscar el elemento en la lista
                T find = _entities
                                .Where(x => Convert.ToInt32(property.GetValue(x)) == id)
                                .FirstOrDefault();

                if (find == null)
                {
                    return "El elemento no se encontró";
                }
                // obtener todas las propiedades de la entidad
                PropertyInfo[] properties = find.GetType().GetProperties();

                foreach (PropertyInfo prop in properties)
                {
                    //no modificar el id
                    if (prop.Name == property.Name)
                    {
                        continue;
                    }
                    //obtengo el valor nuevo
                    object value = prop.GetValue(entity);
                    //asigno el nuevo valor a lo existente
                    prop.SetValue(find, value);
                }

                return "El elemento se modificó correctamente";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="nid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(string nid, int id)
        {
            try
            {
                if (_entities.Count < 1)
                {
                    return "El elemento no se encontró";
                }
                T entity = new T();
                //obtener la propiedad que es el id 
                PropertyInfo property = entity.GetType().GetProperty(nid);

                //buscar el elemento en la lista
                T find = _entities
                                .Where(x => Convert.ToInt32(property.GetValue(x)) == id)
                                .FirstOrDefault();

                if (find == null)
                {
                    return "El elemento no se encontró";
                }
                _entities.Remove(find);
                return "El elemento se eliminó correctamente";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
    }
}

