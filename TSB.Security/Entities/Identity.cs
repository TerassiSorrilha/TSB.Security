using System;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace TSB.Security.Entities
{
    /// <summary>
    /// Define a funcionalidade básica de um objeto IIdentity.
    /// Um objeto identidade representa o usuário em cujo nome o código está sendo executado.
    /// </summary>
    [Serializable]
    public class Identity : IIdentity, ISerializable
    {
        private IUser _user;
        private String _authenticationType;

        /// <summary>
        /// Cria uma nova instancia de uma Identidade.
        /// </summary>
        /// <param name="User">Objeto IUser com os dados do usuário a ser criada a Identitdade.</param>
        /// <param name="AuthenticationType">O tipo de autenticação usado para identificar o usuário.</param>
        public Identity(IUser User, String AuthenticationType)
        {
            _user = User;
            _authenticationType = AuthenticationType;
        }

        /// <summary>
        /// Tipo de autenticação usado para identificar o usuário.
        /// </summary>
        public string AuthenticationType
        { get { return _authenticationType; } }

        /// <summary>
        /// Recebe um valor que indica se o usuário foi autenticado.
        /// </summary>
        public bool IsAuthenticated
        { get { return true; } }

        /// <summary>
        /// Obtém o nome do usuário atual.
        /// </summary>
        public string Name
        { get { return _user.UserName; } }

        /// <summary>
        /// Obtém o objeto IUser autenticado
        /// </summary>
        public IUser User
        { get { return _user; } }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (context.State == StreamingContextStates.CrossAppDomain)
            {
                GenericIdentity gIdent = new GenericIdentity(this.Name, this.AuthenticationType);
                info.SetType(gIdent.GetType());

                System.Reflection.MemberInfo[] serializableMembers;
                object[] serializableValues;

                serializableMembers = FormatterServices.GetSerializableMembers(gIdent.GetType());
                serializableValues = FormatterServices.GetObjectData(gIdent, serializableMembers);

                for (int i = 0; i < serializableMembers.Length; i++)
                {
                    info.AddValue(serializableMembers[i].Name, serializableValues[i]);
                }
            }
            else
            {
                throw new InvalidOperationException("Serialization not supported");
            }
        }
    }
}
