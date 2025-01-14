export type Pagination<G> = {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: G[];
};
