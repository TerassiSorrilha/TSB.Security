using System;
namespace TSB.Security.Entities
{
    /// <summary>
    /// Define a funcionalidade básica de um objeto IUser.
    /// Um objeto IUser armazena os dados de um usuário e pode ser incluida na identidade (IIdentity)
    /// de um contexto de segurança IPrincipal.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Serializa o objeto em uma cadeia XML
        /// </summary>
        /// <returns>String com a cadeia XML que representa o objeto</returns>
        String ToXml();

        /// <summary>
        /// Códico que identifica o usuário
        /// </summary>
        String Id { get; }

        /// <summary>
        /// Nome de usuário, geralmente o apelido utilizado na autenticação
        /// </summary>
        String UserName { get; }

        /// <summary>
        /// Nome completo do usuário
        /// </summary>
        String FullName { get; }

        /// <summary>
        /// Primeiro nome do usuário
        /// </summary>
        String GivenName { get; }

        /// <summary>
        /// Ultimo nome do usuário
        /// </summary>
        String SurName { get; }

        /// <summary>
        /// Matrícula do usuário na empresa
        /// </summary>
        String Matricula { get; }

        /// <summary>
        /// CPF do usuário
        /// </summary>
        String CPF { get; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        String Email { get; }

        /// <summary>
        /// Email privado do usuário
        /// </summary>
        String PrivateEmail { get; }

        /// <summary>
        /// Localização cooporativa do usuário
        /// </summary>
        String Location { get; }

        /// <summary>
        /// Grupo de segurança do usuário
        /// </summary>
        String Group { get; }

        /// <summary>
        /// Empresa do usuário quando for terceirizado
        /// </summary>
        String Outsourced { get; }

    }
}
