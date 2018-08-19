using System;
using System.IO;
using System.Xml.Serialization;

namespace TSB.Security.Entities
{
    /// <summary>
    /// Define a funcionalidade básica de um objeto IUser.
    /// Um objeto IUser armazena os dados de um usuário e pode ser incluida na identidade (IIdentity)
    /// de um contexto de segurança IPrincipal.
    /// </summary>
    [Serializable]
    public class User : IUser
    {

        public User()
        {
            Id = null;
            UserName = null;
            FullName = null;
            GivenName = null;
            SurName = null;
            Matricula = null;
            CPF = null;
            Email = null;
            PrivateEmail = null;
            Location = null;
            Group = null;
            Outsourced = null;
        }

        /// <summary>
        /// Serializa o objeto em uma cadeia XML
        /// </summary>
        /// <returns>String com a cadeia XML que representa o objeto</returns>
        public string ToXml()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            serializer.Serialize(sw, this);
            sw.Close();

            return sw.ToString();
        }

        /// <summary>
        /// Cria uma nova instancia de IUser deserializando uma cadeira XML
        /// </summary>
        /// <param name="UserXml">Cadeia XML que representa o objeto</param>
        /// <returns>Instancia do objeto IUser definido na cadeia XML passada por parametro</returns>
        public static User CreateUser(string UserXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            User ud = (User)serializer.Deserialize(new StringReader(UserXml));
            return ud;
        }

        /// <summary>
        /// Códico que identifica o usuário
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nome de usuário, geralmente o apelido utilizado na autenticação
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Nome completo do usuário
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Primeiro nome do usuário
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Ultimo nome do usuário
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Matrícula do usuário na empresa
        /// </summary>
        public string Matricula { get; set; }

        /// <summary>
        /// CPF do usuário
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Email privado do usuário
        /// </summary>
        public string PrivateEmail { get; set; }

        /// <summary>
        /// Localização cooporativa do usuário
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Código do grupo de segurança padrão do usuário
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Empresa do usuário quando for terceirizado
        /// </summary>
        public string Outsourced { get; set; }
    }
}
