namespace MinialAPI.Model
{
    public class RepositorioPessoa
    {
        public RepositorioPessoa(bool dados)
        {
            if (dados)
            {
                CriarDadosEmMemoria();
            }
            else
            {
                ListaPessoas = new List<Pessoa>();
            }
        }
        private void CriarDadosEmMemoria()
        {
            this.ListaPessoas = new()
            {
                new Pessoa()
                {
                    Nome = "Jonathan Salles Araujo",
                    CPF = "004.632.129-24",
                    Email = "jonathan.araujo@geradornv.com.br"
                },
                new Pessoa()
                {
                    Nome = "Elielson Amorim Assis",
                    CPF = "646.746.742-63",
                    Email = "elielson.assis@geradornv.com.br"
                },
                new Pessoa()
                {
                    Nome = "Daniele Valle Pereira",
                    CPF = "474.321.635-45",
                    Email = "daniele.pereira@geradornv.com.br"
                }

            };
        }
        public List<Pessoa> ListaPessoas { get; set; }

        public Pessoa AdicionarPessoas(Pessoa p)
        {
            ListaPessoas.Add(p);
            return p;
        }

        public bool RemoverPessoas (string cpf)
        {
            var pessoaTemp = (from pessoa in this.ListaPessoas
                              where pessoa.CPF == cpf
                              select pessoa).SingleOrDefault();

            if (pessoaTemp == null)
            {
                return false;
            }

            var removido = ListaPessoas.Remove(pessoaTemp);

            return removido;
        }

        public Pessoa SelecionarPessoa( string cpf)
        {
            var pessoaTemp = (from pessoa in ListaPessoas
                              where pessoa.CPF == cpf
                              select pessoa).SingleOrDefault();

            if (pessoaTemp == null)
            {
                return new Pessoa();
            }

            return pessoaTemp;
        }

        public List<Pessoa> ListarPessoas()
        {
            return this.ListaPessoas;
        }

         public bool AtuaizarPessoas(Pessoa p)
        {
            var pessoaTemp = (from pessoa in this.ListaPessoas
                              where pessoa.CPF == p.CPF
                              select pessoa).SingleOrDefault();

            if (pessoaTemp ==  null)
            {
                return false;
            }

            pessoaTemp.Identificador = p.Identificador;
            pessoaTemp.Nome = p.Nome;
            return true;
        }
    }
}
