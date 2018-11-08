package gruppe4svin.farmville.Views;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;

import java.util.ArrayList;

import gruppe4svin.farmville.Models.Barn;
import gruppe4svin.farmville.Models.Farm;
import gruppe4svin.farmville.R;

public class BarnOverview extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.barn_overview);
        Farm farm = GetFarmData();
        AddBarnsToView(farm);
    }

    private Farm GetFarmData() {
        Bundle extras = getIntent().getExtras();
        Intent intentIncoming = getIntent();
        if (extras != null) {
            return intentIncoming.getParcelableExtra ("farm");
        }
        return null;

    }

    private void AddBarnsToView(Farm farm) {

        final LinearLayout farmOverview = findViewById(R.id.barnOverviewLinearLayout);

        ArrayList<Barn> barns = farm.getBarns();

        for (int i = 0; i < barns.size(); i++) {

            Button btn = new Button(this);
            btn.setId(i);
            btn.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
            btn.setHeight(300);
            final int id_ = btn.getId();
            btn.setText("Stald " + id_);

            /*btn.setOnClickListener(new View.OnClickListener() {
                public void onClick(View v) {
                    AddBoxesToView(farmOverview);
                }
            });*/

            farmOverview.addView(btn);
        }
    }
}
