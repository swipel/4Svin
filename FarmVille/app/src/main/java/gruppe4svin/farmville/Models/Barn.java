package gruppe4svin.farmville.Models;

import java.util.ArrayList;
import java.util.List;

public class Barn {
    private int number;
    private ArrayList<Box> boxes;

    public Barn(int number, ArrayList<Box> boxes) {
        this.number = number;
        this.boxes = boxes;
    }
}
