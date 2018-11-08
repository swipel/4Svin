package gruppe4svin.farmville.Managers;

import gruppe4svin.farmville.DataAccess.ApiConnector;
import gruppe4svin.farmville.Models.Farm;

public class FarmManager {
    private ApiConnector connector = new ApiConnector();

    public void FeedFarm() {

    }

    public void UpdateBox() {


    }

    public Farm GetFarmData() {

        return connector.GetFarmData();

    }

}
