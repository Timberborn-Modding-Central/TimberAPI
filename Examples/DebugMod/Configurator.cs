using Bindito.Core;
using TimberApi.AssetSystem;
using TimberApi.ConfiguratorSystem;
using TimberApi.PresetSystem;
using TimberApi.SceneSystem;
using TimberApi.ShaderSystem;
using UnityEngine;

namespace DebugMod
{
    [Configurator(SceneEntrypoint.All)]
    public class Configurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            // containerDefinition.Bind<TestButtonBuilder>().AsTransient();
            
            containerDefinition.BindPreset<ButtonPreset>();
            containerDefinition.BindPreset<ButtonPreset1>();
            containerDefinition.BindPreset<ButtonPreset2>();
            containerDefinition.BindPreset<ButtonPreset3>();
            containerDefinition.BindPreset<ButtonPreset4>();
            containerDefinition.BindPreset<ButtonPreset5>();
            containerDefinition.BindPreset<ButtonPreset6>();
            containerDefinition.BindPreset<ButtonPreset7>();
            containerDefinition.BindPreset<ButtonPreset8>();
            containerDefinition.BindPreset<ButtonPreset9>();
            containerDefinition.BindPreset<ButtonPreset10>();
            containerDefinition.BindPreset<ButtonPreset11>();
            containerDefinition.BindPreset<ButtonPreset12>();
            containerDefinition.BindPreset<ButtonPreset13>();
            containerDefinition.BindPreset<ButtonPreset14>();
            containerDefinition.BindPreset<ButtonPreset15>();
            containerDefinition.BindPreset<ButtonPreset16>();
            containerDefinition.BindPreset<ButtonPreset17>();
            containerDefinition.BindPreset<ButtonPreset18>();
            containerDefinition.BindPreset<ButtonPreset19>();
            containerDefinition.BindPreset<ButtonPreset20>();
            containerDefinition.BindPreset<ButtonPreset21>();
            containerDefinition.BindPreset<ButtonPreset22>();
            containerDefinition.BindPreset<ButtonPreset23>();
            containerDefinition.BindPreset<ButtonPreset24>();
            containerDefinition.BindPreset<ButtonPreset25>();
            containerDefinition.BindPreset<ButtonPreset26>();
            containerDefinition.BindPreset<ButtonPreset27>();
            containerDefinition.BindPreset<ButtonPreset28>();
            containerDefinition.BindPreset<ButtonPreset29>();
            containerDefinition.BindPreset<ButtonPreset30>();
            containerDefinition.BindPreset<ButtonPreset31>();
            containerDefinition.BindPreset<ButtonPreset32>();
            containerDefinition.BindPreset<ButtonPreset33>();
            containerDefinition.BindPreset<ButtonPreset34>();
            containerDefinition.BindPreset<ButtonPreset35>();
            containerDefinition.BindPreset<ButtonPreset36>();
            containerDefinition.BindPreset<ButtonPreset37>();
            containerDefinition.BindPreset<ButtonPreset38>();
            containerDefinition.BindPreset<ButtonPreset39>();
            containerDefinition.BindPreset<ButtonPreset40>();
            containerDefinition.BindPreset<ButtonPreset41>();
            containerDefinition.BindPreset<ButtonPreset42>();
            containerDefinition.BindPreset<ButtonPreset43>();
            containerDefinition.BindPreset<ButtonPreset44>();
            containerDefinition.BindPreset<ButtonPreset45>();
            containerDefinition.BindPreset<ButtonPreset46>();
            containerDefinition.BindPreset<ButtonPreset47>();
            containerDefinition.BindPreset<ButtonPreset48>();
            containerDefinition.BindPreset<ButtonPreset49>();
            containerDefinition.BindPreset<ButtonPreset50>();
            containerDefinition.BindPreset<ButtonPreset51>();
            containerDefinition.BindPreset<ButtonPreset52>();
            containerDefinition.BindPreset<ButtonPreset53>();
            containerDefinition.BindPreset<ButtonPreset54>();
            containerDefinition.BindPreset<ButtonPreset55>();
            containerDefinition.BindPreset<ButtonPreset56>();
            containerDefinition.BindPreset<ButtonPreset57>();
            containerDefinition.BindPreset<ButtonPreset58>();
            containerDefinition.BindPreset<ButtonPreset59>();
            containerDefinition.BindPreset<ButtonPreset60>();
            containerDefinition.BindPreset<ButtonPreset61>();
            containerDefinition.BindPreset<ButtonPreset62>();
            containerDefinition.BindPreset<ButtonPreset63>();
            containerDefinition.BindPreset<ButtonPreset64>();
            containerDefinition.BindPreset<ButtonPreset65>();
            containerDefinition.BindPreset<ButtonPreset66>();
            containerDefinition.BindPreset<ButtonPreset67>();
            containerDefinition.BindPreset<ButtonPreset68>();
            containerDefinition.BindPreset<ButtonPreset69>();
            containerDefinition.BindPreset<ButtonPreset70>();
            containerDefinition.BindPreset<ButtonPreset71>();
            containerDefinition.BindPreset<ButtonPreset72>();
            containerDefinition.BindPreset<ButtonPreset73>();
            containerDefinition.BindPreset<ButtonPreset74>();
            containerDefinition.BindPreset<ButtonPreset75>();
            containerDefinition.BindPreset<ButtonPreset76>();
            containerDefinition.BindPreset<ButtonPreset77>();
            containerDefinition.BindPreset<ButtonPreset78>();
            containerDefinition.BindPreset<ButtonPreset79>();
            containerDefinition.BindPreset<ButtonPreset80>();
            containerDefinition.BindPreset<ButtonPreset81>();
            containerDefinition.BindPreset<ButtonPreset82>();
            containerDefinition.BindPreset<ButtonPreset83>();
            containerDefinition.BindPreset<ButtonPreset84>();
            containerDefinition.BindPreset<ButtonPreset85>();
            containerDefinition.BindPreset<ButtonPreset86>();
            containerDefinition.BindPreset<ButtonPreset87>();
            containerDefinition.BindPreset<ButtonPreset88>();
            containerDefinition.BindPreset<ButtonPreset89>();
            containerDefinition.BindPreset<ButtonPreset90>();
            containerDefinition.BindPreset<ButtonPreset91>();
            containerDefinition.BindPreset<ButtonPreset92>();
            containerDefinition.BindPreset<ButtonPreset93>();
            containerDefinition.BindPreset<ButtonPreset94>();
            containerDefinition.BindPreset<ButtonPreset95>();
            containerDefinition.BindPreset<ButtonPreset96>();
            containerDefinition.BindPreset<ButtonPreset97>();
            containerDefinition.BindPreset<ButtonPreset98>();
            containerDefinition.BindPreset<ButtonPreset99>();
            

            containerDefinition.BindPreset<ButtonPreset110>();
            containerDefinition.BindPreset<ButtonPreset111>();
            containerDefinition.BindPreset<ButtonPreset112>();
            containerDefinition.BindPreset<ButtonPreset113>();
            containerDefinition.BindPreset<ButtonPreset114>();
            containerDefinition.BindPreset<ButtonPreset115>();
            containerDefinition.BindPreset<ButtonPreset116>();
            containerDefinition.BindPreset<ButtonPreset117>();
            containerDefinition.BindPreset<ButtonPreset118>();
            containerDefinition.BindPreset<ButtonPreset119>();
            containerDefinition.BindPreset<ButtonPreset120>();
            containerDefinition.BindPreset<ButtonPreset121>();
            containerDefinition.BindPreset<ButtonPreset122>();
            containerDefinition.BindPreset<ButtonPreset123>();
            containerDefinition.BindPreset<ButtonPreset124>();
            containerDefinition.BindPreset<ButtonPreset125>();
            containerDefinition.BindPreset<ButtonPreset126>();
            containerDefinition.BindPreset<ButtonPreset127>();
            containerDefinition.BindPreset<ButtonPreset128>();
            containerDefinition.BindPreset<ButtonPreset129>();
            containerDefinition.BindPreset<ButtonPreset130>();
            containerDefinition.BindPreset<ButtonPreset131>();
            containerDefinition.BindPreset<ButtonPreset132>();
            containerDefinition.BindPreset<ButtonPreset133>();
            containerDefinition.BindPreset<ButtonPreset134>();
            containerDefinition.BindPreset<ButtonPreset135>();
            containerDefinition.BindPreset<ButtonPreset136>();
            containerDefinition.BindPreset<ButtonPreset137>();
            containerDefinition.BindPreset<ButtonPreset138>();
            containerDefinition.BindPreset<ButtonPreset139>();
            containerDefinition.BindPreset<ButtonPreset140>();
            containerDefinition.BindPreset<ButtonPreset141>();
            containerDefinition.BindPreset<ButtonPreset142>();
            containerDefinition.BindPreset<ButtonPreset143>();
            containerDefinition.BindPreset<ButtonPreset144>();
            containerDefinition.BindPreset<ButtonPreset145>();
            containerDefinition.BindPreset<ButtonPreset146>();
            containerDefinition.BindPreset<ButtonPreset147>();
            containerDefinition.BindPreset<ButtonPreset148>();
            containerDefinition.BindPreset<ButtonPreset149>();
            containerDefinition.BindPreset<ButtonPreset150>();
            containerDefinition.BindPreset<ButtonPreset151>();
            containerDefinition.BindPreset<ButtonPreset152>();
            containerDefinition.BindPreset<ButtonPreset153>();
            containerDefinition.BindPreset<ButtonPreset154>();
            containerDefinition.BindPreset<ButtonPreset155>();
            containerDefinition.BindPreset<ButtonPreset156>();
            containerDefinition.BindPreset<ButtonPreset157>();
            containerDefinition.BindPreset<ButtonPreset158>();
            containerDefinition.BindPreset<ButtonPreset159>();
            containerDefinition.BindPreset<ButtonPreset160>();
            containerDefinition.BindPreset<ButtonPreset161>();
            containerDefinition.BindPreset<ButtonPreset162>();
            containerDefinition.BindPreset<ButtonPreset163>();
            containerDefinition.BindPreset<ButtonPreset164>();
            containerDefinition.BindPreset<ButtonPreset165>();
            containerDefinition.BindPreset<ButtonPreset166>();
            containerDefinition.BindPreset<ButtonPreset167>();
            containerDefinition.BindPreset<ButtonPreset168>();
            containerDefinition.BindPreset<ButtonPreset169>();
            containerDefinition.BindPreset<ButtonPreset170>();
            containerDefinition.BindPreset<ButtonPreset171>();
            containerDefinition.BindPreset<ButtonPreset172>();
            containerDefinition.BindPreset<ButtonPreset173>();
            containerDefinition.BindPreset<ButtonPreset174>();
            containerDefinition.BindPreset<ButtonPreset175>();
            containerDefinition.BindPreset<ButtonPreset176>();
            containerDefinition.BindPreset<ButtonPreset177>();
            containerDefinition.BindPreset<ButtonPreset178>();
            containerDefinition.BindPreset<ButtonPreset179>();
            containerDefinition.BindPreset<ButtonPreset180>();
            containerDefinition.BindPreset<ButtonPreset181>();
            containerDefinition.BindPreset<ButtonPreset182>();
            containerDefinition.BindPreset<ButtonPreset183>();
            containerDefinition.BindPreset<ButtonPreset184>();
            containerDefinition.BindPreset<ButtonPreset185>();
            containerDefinition.BindPreset<ButtonPreset186>();
            containerDefinition.BindPreset<ButtonPreset187>();
            containerDefinition.BindPreset<ButtonPreset188>();
            containerDefinition.BindPreset<ButtonPreset189>();
            containerDefinition.BindPreset<ButtonPreset190>();
            containerDefinition.BindPreset<ButtonPreset191>();
            containerDefinition.BindPreset<ButtonPreset192>();
            containerDefinition.BindPreset<ButtonPreset193>();
            containerDefinition.BindPreset<ButtonPreset194>();
            containerDefinition.BindPreset<ButtonPreset195>();
            containerDefinition.BindPreset<ButtonPreset196>();
            containerDefinition.BindPreset<ButtonPreset197>();
            containerDefinition.BindPreset<ButtonPreset198>();
            containerDefinition.BindPreset<ButtonPreset199>();
        }
    }
    
    [Configurator(SceneEntrypoint.InGame)]
    public class InGameConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            
        }
    }
    
    [Configurator(SceneEntrypoint.MainMenu)]
    public class MainMenuConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            
        }
    }
}