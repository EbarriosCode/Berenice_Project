export interface AlbumModel
{
    albumID: number,
    title: string;
    artistID: number;
    price: number;
    date: Date;
    availableToPurchase: boolean;
}