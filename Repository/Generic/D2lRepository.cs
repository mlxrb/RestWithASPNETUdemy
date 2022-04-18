using D2L.Extensibility.AuthSdk;
using D2L.Extensibility.AuthSdk.Restsharp;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestWithASPNETUdemy.Configurations;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{

    public class D2lRepository<T, D, F> : ID2lRepository<T, D, F>
    {
        private string m_appId;
        private string m_appKey;

        private string LMS_URL;
        private string request_url;

        private const string LP_VERSION = "1.34";

        private const string ROUTE = "/d2l/api/lp/" + LP_VERSION;

        private ID2LAppContext m_valenceAppContext;
        private HostSpec m_valenceHost;
        private ID2LUserContext m_valenceUserContext;

        private RestClient m_client;
        private RestRequest m_request;

        private D m_body;
        private F m_bodyPut;

        private IConfiguration _configuration;
        //seta valores para acessar api da d2l
        public D2lRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            m_appId = _configuration["D2lConfigurations:valence_appId"];
            m_appKey = _configuration["D2lConfigurations:valence_appKey"];
            LMS_URL = _configuration["D2lConfigurations:lms_host"];
            request_url = _configuration["D2lConfigurations:Request_Url"];

            var appFactory = new D2LAppContextFactory();
            m_valenceAppContext = appFactory.Create(m_appId, m_appKey);
            m_valenceHost = new HostSpec("https", LMS_URL, 443);

            m_valenceUserContext = m_valenceAppContext.CreateUserContext(new Uri(request_url), m_valenceHost) as ID2LUserContext;
        }
        private void RequestSet(string servico, string tipo)
        {
            if (tipo == "GET" || tipo == "DELETE") m_request = new RestRequest(ROUTE + servico, Method.GET);           
            if (tipo == "POST")
            {
                m_request = new RestRequest(ROUTE + servico, Method.POST);
                m_request.RequestFormat = DataFormat.Json;
                m_request.AddJsonBody(m_body);                                 
            }
            if (tipo == "PUT")
            {
                m_request = new RestRequest(ROUTE + servico, Method.PUT);
                m_request.RequestFormat = DataFormat.Json;
                m_request.AddJsonBody(m_bodyPut);                                  
            }       
        }
        private void ExecutarOsServicos (string servico, List<ParamLista> param, string tipo)
        {
            if (m_valenceUserContext == null)
            {
                throw new Exception("This method can only be used for an authenticated user");
            }
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            m_client = new RestClient("https://" + LMS_URL);
            var authenticator = new ValenceAuthenticator(m_valenceUserContext);
            RequestSet(servico, tipo);
            authenticator.Authenticate(m_client, m_request);
            if (param != null)
            {
                param.ForEach(delegate (ParamLista p)
                {
                    m_request.AddParameter(p.Atributo, p.Value, ParameterType.GetOrPost);
                });
            }
        }
        //Executa serviços com retorno de único objeto
        private T ExecuteService(string servico, List<ParamLista> param, string tipo)
        {

            ExecutarOsServicos(servico, param, tipo);
           
            var response = m_client.Execute<T>(m_request);

            return response.Data;
        }

        //Executa serviços com retorno de lista de objetos
        private List<T> ExecuteServices(string servico, List<ParamLista> param, string tipo)
        {
            ExecutarOsServicos(servico, param, tipo);

            var response = m_client.Execute<List<T>>(m_request);

            return response.Data;
        }

        public List<T> GetList(string servico, List<ParamLista> param)
        {
            return ExecuteServices(servico, param, "GET");
        }

        public T Get(string servico, List<ParamLista> param)
        {
            return ExecuteService(servico, param, "GET");
        }

        public T Post(string servico, List<ParamLista> param, D body)
        {
            m_body = body;
            return ExecuteService(servico, param, "POST");
        }

        public T Put(string servico, List<ParamLista> param, F body)
        {
            m_bodyPut = body;
            return ExecuteService(servico, param, "PUT");
        }

        public T Delete(string servico, List<ParamLista> param)
        {            
            return ExecuteService(servico, param, "DELETE");
        }
    } 
}
