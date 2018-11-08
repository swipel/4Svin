package gruppe4svin.farmville.Models;

public class Box {
    private int typeId, amount;
    private String typeName;

    public Box(int amount, int typeId, String typeName) {
        this.amount = amount;
        this.typeId = typeId;
        this.typeName = typeName;
    }
}
