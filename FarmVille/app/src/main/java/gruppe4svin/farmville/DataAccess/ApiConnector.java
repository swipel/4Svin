package gruppe4svin.farmville.DataAccess;

import java.util.ArrayList;
import java.util.List;

import gruppe4svin.farmville.Models.Barn;
import gruppe4svin.farmville.Models.Box;
import gruppe4svin.farmville.Models.Farm;

public class ApiConnector {

    ArrayList<Barn> barns = new ArrayList<>();
    ArrayList<Box> boxes = new ArrayList<>();


    Farm mockFarm;
    {
        mockFarm = new Farm(1, barns);
    }

    private void MockFill() {
        boxes.add(new Box(10, 3, "Smågris"));
        boxes.add(new Box(20, 2, "So"));
        boxes.add(new Box(1, 1, "Orne"));


        barns.add(new Barn(1, boxes));
        barns.add(new Barn(2, boxes));
        barns.add(new Barn(3, boxes));
    }


    public void FeedFarm() {

    }

    public void UpdateBox() {

    }

    public Farm GetFarmData() {
        MockFill();
        return mockFarm;
    }
}
