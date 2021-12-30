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

        public long CountQuantityDocumentsClientesDAO(IMongoCollection<Cliente> clienteCollection) 
        {
            return clienteCollection.CountDocuments(Builders<Cliente>.Filter.Empty);
        }

        public Cliente GetLastInsertedDocumentClientesDAO(IMongoCollection<Cliente> clienteCollection) 
        {
            var filter = Builders<Cliente>.Filter.Empty;
            var document = clienteCollection.Find<Cliente>(filter).SortByDescending( b => b.Id).Limit(1).ToList();
            
            Cliente lastDocument = new Cliente();

            foreach (Cliente c in document) 
            {
                lastDocument = c;
            }

            return lastDocument;
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

        public List<Cliente> ListClientesByDataDAO(IMongoCollection<Cliente> clienteCollection, string data)
        {
            var filter = Builders<Cliente>.Filter.Where(b => b.Data == data);
            var clientes = clienteCollection.Find<Cliente>(filter).SortBy(b => b.Id).ToList();

            return clientes;
        }

        public Cliente GetClienteByCodigoDAO(IMongoCollection<Cliente> clienteCollection, int id, string data)
        {
            Cliente cliente = new Cliente();
            var clientes = clienteCollection.Find(x => x.Id == id && x.Data == data).ToList();

            foreach (Cliente c in clientes)
            {
                cliente = c;
            }

            return cliente;
        }

        public void UpdateClienteDAO(IMongoCollection<Cliente> clienteCollection, Cliente infoCliente, string data, int id)
        {
            // b => b.Data == data
            var filter = Builders<Cliente>.Filter.Where(b => b.Id == id && b.Data == data);
            var clienteUpdate = Builders<Cliente>.Update
                .Set(b => b.Nome, infoCliente.Nome)
                .Set(b => b.Senha, infoCliente.Senha)
                .Set(b => b.Idade, infoCliente.Idade);

            clienteCollection.UpdateOne(filter, clienteUpdate);
        }

        public void DeleteClienteDAO(IMongoCollection<Cliente> clienteCollection, int id, string data)
        {
            var filter = Builders<Cliente>.Filter.Where(b => b.Id == id && b.Data == data);

            clienteCollection.DeleteOne(filter);
        }
    }
}
