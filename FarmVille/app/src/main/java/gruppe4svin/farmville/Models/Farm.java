package gruppe4svin.farmville.Models;

import java.util.ArrayList;
import java.util.List;

public class Farm {
    private int farmId;
    private ArrayList<Barn> barns;



    public Farm(int farmId, ArrayList<Barn> barns) {
        this.farmId = farmId;
        this.barns = barns;
    }

    public ArrayList<Barn> getBarns() {
        return barns;
    }

    public void setBarns(ArrayList<Barn> barns) {
        this.barns = barns;
    }

    public int getFarmId() {
        return farmId;
    }

    public void setFarmId(int farmId) {
        this.farmId = farmId;
    }
}
