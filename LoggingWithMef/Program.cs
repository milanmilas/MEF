using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingWithMef.v1;
using LoggingWithMef.v2;
using NLog;

namespace LoggingWithMef
{
    public class LogExportProvider : ExportProvider
    {
        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            if (definition.ContractName.StartsWith("ILogger2~"))
            {
                return new List<Export>{ new Export(definition.ContractName, () => new NLogger2(definition.ContractName.Substring("ILogger2~".Length)))};
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //V1();
            V2();
        }
        
        static void V2()
        {
            var conventions = new RegistrationBuilder();

            conventions
                .ForTypesMatching(
                    t => t.GetProperties().Any(p => p.PropertyType == typeof (ILogger2)))
                .ImportProperties(
                    propertyFilter => propertyFilter.PropertyType == typeof (ILogger2),
                    (propertyInfo, builder) =>
                        builder.AsContractName("ILogger2~" + propertyInfo.DeclaringType.FullName))
                .Export(); // Export for worker2 class

            var catalog = new AssemblyCatalog(typeof(Program).Assembly, conventions);

            var container =  new CompositionContainer(catalog, new LogExportProvider());


            var v = container.GetExport<Worker2>().Value;

            v.DoWork();

            v= new Worker2();

            container.ComposeParts(v);

            v.DoWork(); // exception

            Console.ReadKey();
        }

        // V1 set up contract implementation at the run time
        static void V1()
        {

            http://geekswithblogs.net/abhijeetp/archive/2011/10/30/mef-101---part-2.aspx
            //AggregateCatalog
            //ApplicationCatalog
            //AssemblyCatalog
            //CatalogChangeProxy
            //CompositionScopeDefinition
            //DirectoryCatalog
            //FilteredCatalog
            //TypeCatalog

            var registrationBuilder = new RegistrationBuilder();
            registrationBuilder
                .ForTypesMatching<ILogger1>(t => t.Name != "NLogger1");
            //.ExportInterfaces();

            var assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly, registrationBuilder);
            var container = new CompositionContainer(assemblyCatalog);

            var worker = new Worker1();
            container.ComposeParts(worker);
            worker.DoWork();

            Console.ReadKey();
        }
    }
}
