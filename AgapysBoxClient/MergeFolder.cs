using AgapysBoxCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgapysBoxCore
{
    public class MergeFolder
    {
        //TODO: Criar lógica para não precisar reenviar e salvar sempre os arquivos (principalmente os binários)
        //TODO: Criar sistema de autenticação
        //TODO: Criar estrutura de LOCK dos arquivos, notificando quando arquivo é alterado
        //TODO: Criar lógica de gravação, verificando datas do arquivo local e do servidor (considerar sempre a ultima data do servidor)
        //TODO: Permitir parametrização de IPs, pastas, e salvar em arquivo para recuperar depois
        //TODO: Criar uma estrutura para exclusão de arquivos.
        //TODO: Criar estrutura de backup
        private List<FileObservable> Files { get; set; }

        public MergeFolder ()
        {

        }


    }
}
