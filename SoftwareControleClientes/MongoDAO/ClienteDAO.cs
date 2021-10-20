using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SoftwareControleClientes.Database;

namespace SoftwareControleClientes.MongoDAO
{
    public sealed class ClienteDAO
    {
        private static ClienteDAO _instance = null;
        private static object SyncLock = new object();

        public static ClienteDAO GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ClienteDAO();
                        }
                    }
                }

                return _instance;
            }
        }

        public IMongoCollection<Cliente> GetClientesCollectionDAO()
        {
            IMongoCollection<Cliente> clientesCollection = MongoDBDatabase.GetConnect.GetCollection<Cliente>("Clientes");
            return clientesCollection;
        }

        public void InsertClienteDAO(IMongoCollection<Cliente> clienteCollection, Cliente novoCliente)
        {
            clienteCollection.InsertOne(novoCliente);
        }

        public List<Cliente> ListClientesDAO(IMongoCollection<Cliente> clienteCollection)
        {
            var filter = Builders<Cliente>.Filter.Empty;
            var clientes = clienteCollection.Find<Cliente>(filter).ToList();
            return clientes;
        }

        public void UpdateClienteDAO(IMongoCollection<Cliente> clienteCollection, Cliente infoCliente, int value, string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(b => b.Codigo, ObjectId.Parse(id));
            var clienteUpdate = Builders<Cliente>.Update
                .Set(b => b.Nome, infoCliente.Nome)
                .Set(b => b.Senha, infoCliente.Senha)
                .Set(b => b.Idade, infoCliente.Idade);

            clienteCollection.UpdateOne(filter, clienteUpdate);
        }

        public void DeleteClienteDAO(IMongoCollection<Cliente> clienteCollection, string id)
        {
            var filter = Builders<Cliente>.Filter.Where(b => b.Codigo == ObjectId.Parse(id));

            clienteCollection.DeleteOne(filter);
        }
    }
}
