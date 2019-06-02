using Entitas;
using RPG.View;

public class ViewFeature : FeatureAttribute { 
    public ViewFeature(int prior = 0) :base(prior) {
        
    }
}

public class TestViewFeature: Systems {
    public TestViewFeature(Contexts contexts) {
        this
        .Add(new TestViewSystem())
        .Add(new ViewSystem())
        .Add(new TransformSystem());
    }
}