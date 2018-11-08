package gruppe4svin.farmville.Views;

import android.content.Intent;
import android.os.Bundle;
import android.os.Parcelable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;

import gruppe4svin.farmville.Managers.FarmManager;
import gruppe4svin.farmville.Models.Farm;
import gruppe4svin.farmville.R;

public class FarmOverview extends AppCompatActivity {

    FarmManager manager = new FarmManager();
    Farm farm = manager.GetFarmData();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.farm_overview);
        AddFarmsToView();
    }

    private void AddFarmsToView() {

        final LinearLayout farmOverview = findViewById(R.id.FarmOverviewLinearLayout);
        for (int i = 0; i < 3; i++) {

            Button btn = new Button(this);
            btn.setId(i);
            btn.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
            btn.setHeight(300);
            btn.setText("Farm " + farm.getFarmId());

            btn.setOnClickListener(farmClickListener);

            farmOverview.addView(btn);
        }
    }

    private View.OnClickListener farmClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            FarmSelected();
        }
    };

    private void FarmSelected() {

        Intent intent = new Intent(this, BarnOverview.class );
        intent.putExtra ("farm", (Parcelable) farm);
        startActivity(intent);
        finish();
    }

    /*private void AddBoxesToView(LinearLayout farmOverview) {

        farmOverview.removeAllViews();

        Button backBtn = new Button(this);

        for (int i = 0; i < 20; i++) {

            Button btn = new Button(this);
            btn.setId(i);
            btn.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
            btn.setHeight(300);
            final int id_ = btn.getId();
            btn.setText("Boks " + id_);

            farmOverview.addView(btn);
        }
    }

    */



    public void FeedFarm(){

    }

    public void UpdateBox() {

    }
}
